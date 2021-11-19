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
    public partial class ipDisplay : Form
    {
        public ipDisplay()
        {
            InitializeComponent();
        }

        public ipDisplay(string ips)
        {
            InitializeComponent();
            textBox1.Text = ips;
        }
    }
}
