using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyatnawki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Form3 gameOption = new Form3(this);
            gameOption.Show();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            string text = "Вы хотите покинуть игру?";
            string windowname = "Выход из игры";
            DialogResult exitDialogue = MessageBox.Show(text, windowname, MessageBoxButtons.YesNo);
            if (exitDialogue == DialogResult.Yes) Application.Exit();

            
        }
    }
}
