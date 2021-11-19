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
    public partial class TimeEdit : Form
    {
        public string Time { get; set; }

        public TimeEdit()
        {
            InitializeComponent();
        }

        public TimeEdit(string originalTime)
        {
            InitializeComponent();
            textBox1.Text = originalTime;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Time = textBox1.Text;
            this.Close();
        }

        private void TimeEdit_Load(object sender, EventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  //enter
            {
                Time = textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyChar == (char)27)   //escape
                this.Close();
        }

        private void TimeEdit_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
