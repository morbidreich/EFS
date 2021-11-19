using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFS
{
    public partial class Bin : Form
    {
        private List<Strip> m_usuniete;

        public Bay FormaBazowa { get; set; }

        public Bin(List<Strip> usuniete)
        {
            InitializeComponent();
            m_usuniete = usuniete;
        }

        public Bin()
        {
            InitializeComponent();
        }

        public void AddSmallStrip(StripSmall smallEfs)
        {
            smallEfs.myBay = FormaBazowa;
            smallEfs.myBin = this;
            pnlBin.Controls.Add(smallEfs);
            pnlBin.Controls.SetChildIndex(smallEfs, 0);
        }

        public void removeFromPnl(StripSmall smallEfs)
        {
            foreach (StripSmall ss in pnlBin.Controls)
            {
                if (ss.Callsign == smallEfs.Callsign)
                    pnlBin.Controls.Remove(ss);
            }
        }

        private void Bin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        internal void ClearList()
        {
            pnlBin.Controls.Clear();
        }

        private void Bin_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FormaBazowa.Location.X + 1100, 500);
        }
    }
}
