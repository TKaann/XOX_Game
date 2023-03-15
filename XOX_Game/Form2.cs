using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1.setPlayerNames(p1.Text, p2.Text); ------> oyuncu isimlerini oyun icinde yaziyoruz ekstra form acmadan!!!!!!
            this.Close();
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")//anlasilmadi sorulacak!!!!!!
                button1.PerformClick();
        }
    }
}
