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
    public partial class AddObstacleStrip : Form
    {
        public Strip strip;

        public AddObstacleStrip()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            strip = new Strip();
            strip.TypEFS = Strip.TypPaska.Info;

            try
            {
                strip.m_presetObstSymb = Bay.Exercise.PresetObstSymb;
            }
            catch(Exception) {}
            
            strip.Location = new Point(30, 30);
            strip.Callsign = "";
            this.Controls.Add(strip);
            this.Invalidate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AddObstacleStrip_Load(object sender, EventArgs e)
        {
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = _point.Y;
            Left = _point.X;
        }
    }
}
