using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFS
{
    public partial class AtisWindow : Form
    {
        public string Designator { get; set; }
        private char d;


        public AtisWindow(string desig)
        {
            InitializeComponent();
            this.Designator = desig;
        }

        private void ATIS_Load(object sender, EventArgs e)
        {
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;

            textBox1.Text = Designator;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                d = char.Parse(textBox1.Text);
                d++;

                if (d > 90)
                    d = (char)65;

                textBox1.Text = d.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                d = char.Parse(textBox1.Text);
                d--;

                if (d < 65)
                    d = (char)90;

                textBox1.Text = d.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Designator = textBox1.Text;
                Bay.ATIS = Designator;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void AtisWindow_Shown(object sender, EventArgs e)
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);

            //if ((this.Left + this.Width) > currentScreen.Bounds.Width)
            //    this.Left = currentScreen.Bounds.Width - this.Width;

            //if (this.Left < currentScreen.Bounds.Left)
            //    this.Left = currentScreen.Bounds.Left;

            if ((this.Top + this.Height) > currentScreen.Bounds.Height - 35)
                this.Top = currentScreen.Bounds.Height - this.Height - 35;

            if (this.Top < currentScreen.Bounds.Top)
                this.Top = currentScreen.Bounds.Top;
        }
    }
}
