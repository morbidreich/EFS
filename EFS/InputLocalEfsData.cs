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
    public partial class InputLocalEfsData : Form
    {
        public string Acid { get; set; }
        public string Typ { get; set; }
        public string W { get; set; }

        public InputLocalEfsData()
        {
            InitializeComponent();
        }

        private void InputLocalEfsData_Load(object sender, EventArgs e)
        {
            

            var _point = new System.Drawing.Point(Cursor.Position.X - (this.Width / 2), Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;

            txtAcid.Focus();
            txtAcid.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Acid = txtAcid.Text;
            Typ = txtType.Text;
            W = txtW.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAcid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  //enter
            {
                Acid = txtAcid.Text;
                Typ = txtType.Text;
                W = txtW.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyChar == (char)27)   //escape
                this.Close();
        }
    }
}
