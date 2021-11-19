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
    public partial class ActiveRunway : Form
    {
        public string ArrRwy { set; get; }
        public string DepRwy { set; get; }


        public ActiveRunway(List<string> rwys)
        {
            InitializeComponent();
            foreach (string rwy in rwys)
            {
                cmbArr.Items.Add(rwy);
                cmbDep.Items.Add(rwy);
            }
            if (cmbArr.Items.Count > 0)
                cmbArr.SelectedIndex = 0;

            if (cmbDep.Items.Count > 0)
                cmbDep.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrRwy = cmbArr.SelectedItem.ToString();
            DepRwy = cmbDep.SelectedItem.ToString();

            this.Close();
               
        }

        private void ActiveRunway_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < cmbArr.Items.Count; i++)
                {
                    if (cmbArr.Items[i].ToString().Contains(Bay.ArrRwy))
                        cmbArr.SelectedIndex = i;
                }
                for (int i = 0; i < cmbDep.Items.Count; i++)
                {
                    if (cmbDep.Items[i].ToString().Contains(Bay.DepRwy))
                        cmbDep.SelectedIndex = i;
                }

            }
            catch (Exception)
            { }
        }
    }
}
