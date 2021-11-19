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
    public partial class FreeTextWindow : Form
    {
        public string FreeText { get; set; }

        public FreeTextWindow()
        {
            InitializeComponent();
        }

        private void FreeTextWindow_Load(object sender, EventArgs e)
        {
           
            this.BackColor = Color.Turquoise;

            var _point = new System.Drawing.Point(Cursor.Position.X - (this.Width / 2), Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;

            button1.Width = this.Width;
            textBox1.Width = this.Width;
            textBox1.MaxLength = 7;
            textBox1.Focus();
            textBox1.Select();
            button2.Width = this.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FreeText = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  //enter
            {
                FreeText = textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyChar == (char)27)   //escape
                this.Close();

        }

        private void FreeTextWindow_Shown(object sender, EventArgs e)
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);



            Point pt = new Point();

            pt.X = Cursor.Position.X - this.Width / 2;
            pt.Y = Cursor.Position.Y;

            this.Location = pt;



            //if ((this.Left + this.Width) > currentScreen.Bounds.Width)
            //    this.Left = currentScreen.Bounds.Width - this.Width;

            //if (this.Left < currentScreen.Bounds.Left)
            //    this.Left = currentScreen.Bounds.Left;

            if ((this.Top + this.Height) > currentScreen.Bounds.Height - 40)
                this.Top = currentScreen.Bounds.Height - this.Height - 40;

            if (this.Top < currentScreen.Bounds.Top)
                this.Top = currentScreen.Bounds.Top;
        }
    }
}
