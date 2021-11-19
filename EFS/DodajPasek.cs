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
    public partial class DodajPasek : Form
    {
        public Strip efs;
        

        public DodajPasek()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radInfo.Checked)
                efs = new Strip(textBox1.Text);
            else if (radArr.Checked || radDep.Checked)
                efs = DodajPasekArrDep();

            this.Close();
        }

        private Strip DodajPasekArrDep()
        {
            FlightPlan fpl = new FlightPlan();

            if (radArr.Checked)
                fpl.FltType = FlightPlan.TypLotu.Arr;
            else if (radDep.Checked)
                fpl.FltType = FlightPlan.TypLotu.Dep;

            fpl.Callsign = txtCallsign.Text;
            fpl.Typ = txtType.Text;

            foreach (Control contrl in pnlArr.Controls)
            {
                if (contrl is RadioButton)
                {   
                    RadioButton rb = (RadioButton)contrl;
                    if (rb.Checked)
                        fpl.TransponderType = rb.Text;
                }
                    
            }

            fpl.Squawk = txtSquawk.Text;

            fpl.ADEP = txtADEP.Text;
            fpl.ADEST = txtADEST.Text;

            fpl.RFL = txtRFL.Text;
            fpl.Route = txtRoute.Text;

            
            //fpl.Callsign = pnlArr.Controls
            
            
            
            return new Strip(fpl);
        }

        private void radArr_CheckedChanged(object sender, EventArgs e)
        {
            if (radInfo.Checked)
            {
                pnlArr.Enabled = false;
                pnlInfostrip.Enabled = true;
            }
            else if (radDep.Checked || radArr.Checked)
            {
                pnlArr.Enabled = true;
                pnlInfostrip.Enabled = false;
            }
        }

        private void txtSquawk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {   
                e.Handled = true;
            }
        }
    }
}
