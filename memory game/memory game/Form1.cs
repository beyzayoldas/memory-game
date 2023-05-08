using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace memory_game
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int randomindex;
        Timer t = new Timer();
        Timer t2 = new Timer();

        Button first, second;

        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 2000;
            ShowIcons();
            t2.Tick += T2_Tick;
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Button item in Controls.OfType<Button>())
            {
                item.ForeColor = item.BackColor;
            }
        }

        private void ShowIcons()
        {
            List<string> icons = new List<string>()
            {
                "!", ",", "b", "k", "v", "w", "z", "N",
                "!", ",", "b", "k", "v", "w", "z", "N"
            };

            foreach (Button button in Controls.OfType<Button>())
            {
                randomindex = rnd.Next(icons.Count);
                button.Text = icons[randomindex];
                button.ForeColor = Color.Black;
                icons.RemoveAt(randomindex);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }

            second = btn;
            second.ForeColor = Color.Black;
            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                if (Controls.OfType<Button>().All(button => button.ForeColor == Color.Black))
                {
                    MessageBox.Show("Congratulations! You have matched all icons.");
                    Close();
                }
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }
    }
}
