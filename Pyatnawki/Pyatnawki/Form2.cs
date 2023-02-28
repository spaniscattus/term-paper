using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyatnawki
{
    public partial class Form2 : Form
    {
        public Form2(Form1 gameMenu)
        {
            InitializeComponent();
            this.gameMenu = gameMenu;
            
                  
            
        }
        private Form1 gameMenu;

        GameLogic gl = new GameLogic();

        public int h = 0;
        public int m = 0;
        public int s = 0;
        public int clics = 0;
        

        public int x = 0;
        public int y = 0;
        public int scale = 1;
           
  
        public void gameCell_Click(object sender, EventArgs e)
        {
            
            var button = (Button)sender;
            var cord = button.Location;
            int x = cord.X/(500/scale);
            int y = cord.Y/(500/scale);
            
            
            clics = gl.MoveCell(button, x, y, clics);
            gl.EndGame(timer1, this);
            
        }
        public Point[,] CreateCells(int x, int y, int scale)
        {
            Button[,] buttons = new Button[x, y];
            Point[,] points = new Point[x, y];
            
            int c = 1;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].BackColor = Color.FromArgb(64,64,64);
                    buttons[i, j].ForeColor = Color.White;
                    buttons[i, j].Text = $"{c}";
                    buttons[i, j].Font = new Font(buttons[i,j].Font.FontFamily, 500/scale/3);
                    buttons[i, j].Name = $"game_button{c}";
                    buttons[i, j].Tag = c;
                    buttons[i, j].Size = new Size(500/scale, 500/scale);
                    buttons[i, j].Location = new Point(10 + i * 500/scale, 10 + j * 500/scale) ;
                    points[i, j] = buttons[i, j].Location;
                    buttons[i, j].Click += this.gameCell_Click;

                    this.Controls.Add(buttons[i, j]);
                    c++;
                }
                
            }
            buttons[x-1,y-1].Visible = false;
            buttons[x - 1, y - 1].Text = "0";
            gl.ShuffleGame(buttons, x, y);
            return points;

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameMenu.Show();
            timer1.Stop();
            timer2.Stop();

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
            
            Point[,] gameButtons;
            gl.pole = gl.GameMap(x, y);

            gameButtons = CreateCells(x, y, scale);
            gl.points = gameButtons;
            gl.maxX = x-1;
            gl.maxY = y-1;
            this.Text = $"Время: {h}:{m / 10}{m % 10}:{s / 10}{s % 10} Количество ходов: {clics}";
            timer1.Start();
            timer2.Start();
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            if(s > 59)
            {
                s = 0;
                m += 1;
            }
            if(m > 59)
            {
                m = 0;
                h += 1;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = $"Время: {h}:{m / 10}{m % 10}:{s / 10}{s % 10} Количество ходов: {clics}";
            if (timer1.Enabled == false)
            {
                timer2.Stop();
                string text = $"Вы завершили игру за {h}:{m / 10}{m % 10}:{s / 10}{s % 10} \nВаше количество ходов: {clics}";
                string windowname = "Победа!";
                DialogResult exitDialogue = MessageBox.Show(text, windowname, MessageBoxButtons.OK);
                if (exitDialogue == DialogResult.OK) this.Close();
            }
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
