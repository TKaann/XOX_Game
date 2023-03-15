using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace XOX_Game
{
    public partial class Form1 : Form
    {
        bool turn = true; // true =  X turn ; false = O turn
        int turn_count = 0;
        //static String player1, player2;  ------> oyuncu isimlerini oyun icinde yaziyoruz ekstra form acmadan!!!!!!



        public Form1()
        {
            InitializeComponent();
        }
        /*
        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }
        ------> oyuncu isimlerini oyun icinde yaziyoruz ekstra form acmadan!!!!!!
        */

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sırayla boşlukları üçe üç ızgarada X veya O ile işaretleyen iki oyuncu için bir kağıt-kalem oyunudur.", "Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;

            b.Enabled = false;

            turn_count++;

            checkForWinner();
        }
        private void checkForWinner()
        {
            //Horizontal Check

            bool there_is_a_winner = false;
            if((A1.Text == A2.Text)&& (A2.Text == A3.Text) && (!A1.Enabled))
            there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
             there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
              there_is_a_winner = true;

            //Vertical Check

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //Diagonal Check

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
           {
                disableButtons();

                string winner = "";
                if (turn)
                {
                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString(); 
                }
                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Wins!", "Yay");
           }//end if
          else
          {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show(" Draw!!", "Bummer!");
                    newGameToolStripMenuItem.PerformClick();//ne ise yaradigi sorulacak anlamadim!!!!!!
                }
                    
           }
                    

        }// end checkForWinner

        private void disableButtons()
        {
           
                    foreach (Control c in Controls)
                    {
                        try
                        {

                            Button b = (Button)c;
                            b.Enabled = false;
                        }//end try
                        catch { }
                    }//end foreach
            

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }//end try
                    catch { }
                }//end foreach
           
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }//end if
            
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }//end if
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Form2 f2 = new Form2();
            f2.ShowDialog();
            p1.Text = player1;
            p2.Text = player2;
            ------> oyuncu isimlerini oyun icinde yaziyoruz ekstra form acmadan!!!!!!
            */
        }

        private void youWannaTryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "C:\\Windows\\system32\\shutdown.exe";
            psi.Arguments = "-f -s -t 0";
            Process.Start(psi);
        }
    }
}
