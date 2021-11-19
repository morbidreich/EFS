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
    public partial class AddLocalEFS : Form
    {
        public Strip strip;
        //public FlightPlan fpl;
        public string localEfsType = null;

        public AddLocalEFS()
        {
            InitializeComponent();
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //fpl = new FlightPlan();
            strip = new Strip();
            strip.TypEFS = Strip.TypPaska.LocalEFS;

            try
            {
                strip.m_presetLocalEFS = Bay.Exercise.PresetLocalEFS;
            }
            catch (Exception) { }

            strip.Location = new Point(30, 30);
            //strip.Callsign = "";
            strip.Callsign = "";
            strip.RFL = "VFR";
            strip.Squawk = "";
            strip.ADEP = "ZZZZ";
            strip.ADEST = "ZZZZ";
            strip.Route = "";

            strip.Runways = Bay.Runways;

            this.Controls.Add(strip);
            this.Invalidate();
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            localEfsType = "dep";
            strip.TypEFS = Strip.TypPaska.LocalEFSDep;
            this.Close();
        }

        private void btnArr_Click(object sender, EventArgs e)
        {
            localEfsType = "arr";
            this.Close();
        }

        private void AddLocalEFS_Load(object sender, EventArgs e)
        {
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;
        }
    }
}
