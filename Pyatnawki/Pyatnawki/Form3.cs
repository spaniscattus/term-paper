using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Pyatnawki
{
    public partial class Form3 : Form
    {
        public Form3(Form1 gameMenu)
        {
            InitializeComponent();
            this.gameMenu = gameMenu;
            
        }
        private Form1 gameMenu;
        
        private void gameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameType.SelectedIndex != 3) 
            {
                playButton.Top = 80;
                playButton.Visible = true;
                gameHeight.Visible = false;
                gameWidth.Visible = false;
                YBox.Visible = false;
                XBox.Visible = false;
            }
            else
            {
                playButton.Top = 140;
                playButton.Visible = true;
                gameHeight.Visible = true;
                gameWidth.Visible = true;
                YBox.Visible = true;
                XBox.Visible = true;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            
            Form2 game = new Form2(gameMenu);
            int[] xy = new int[1];
            xy = getCords();
            game.x = xy[0];
            game.y = xy[1];
            if (game.x > game.y) game.scale = game.x;
            else game.scale = game.y;
            game.Show();
            gameMenu.Hide();
            this.Close();
        }
        public int[] getCords()
        {
            int[] cords = new int[2];
            int x = 0;
            int y = 0;
            if (gameType.SelectedIndex == 0) { x = 4; y = 4; }
            if (gameType.SelectedIndex == 1) { x = 6; y = 6; }
            if (gameType.SelectedIndex == 2) { x = 10; y = 10; }
            if (gameType.SelectedIndex == 3) { x = int.Parse(XBox.Text) ; y = int.Parse(YBox.Text); }
            cords[0] = x;
            cords[1] = y;
            return cords;
        }

        private void XBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != 8) e.Handled = true;
        }

        private void YBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != 8) e.Handled = true;
        }
    }
}
