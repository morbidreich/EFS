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
    public partial class SidWindow : Form
    {
        private bool selSid = false;
        public bool UserSelectedSid
        { get { return selSid; } }

        private bool selHdgAlt = false;
        public bool UserSelectedHdgAlt
        { get { return selHdgAlt; } }


        public string SelectedSid { get; set; }

        public SidWindow(List<SID> sidList, string rwy)
        {
            InitializeComponent();

            foreach (SID sid in sidList)
                if (sid.RWY == rwy)
                    lstSid.Items.Add(sid.ProcName);
        }

        private void SID_Load(object sender, EventArgs e)
        {

            
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);

            this.StartPosition = FormStartPosition.Manual;

            Top = _point.Y;
            Left = _point.X;



            for (int i = 0; i < 370; i += 10)
            {
                lstHdg.Items.Add(i.ToString("000"));
            }

            for (int i = 0; i < 250; i += 10)
            {
                lstLvl.Items.Add(i.ToString("000"));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstSid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSid != "")
            {
                SelectedSid = lstSid.SelectedItem.ToString();
                selSid = true;
                this.Close();
            }
        }

        private void SidWindow_Shown(object sender, EventArgs e)
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

        private void lstHdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHdg.SelectedItem != null && lstLvl.SelectedItem != null)
            {  
                selHdgAlt = true;
                SelectedSid = lstHdg.SelectedItem.ToString() + "/" + lstLvl.SelectedItem.ToString();
                this.Close();
            }
        }

        private void lstLvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHdg.SelectedItem != null && lstLvl.SelectedItem != null)
            {
                selHdgAlt = true;
                SelectedSid = lstHdg.SelectedItem.ToString() + "/" + lstLvl.SelectedItem.ToString();
                this.Close();
            }
        }
    }
}
