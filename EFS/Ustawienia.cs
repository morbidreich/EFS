using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace EFS
{
    public partial class Ustawienia : Form
    {
        public Ustawienia()
        {
            InitializeComponent();

            textBox1.Text = EFS.Properties.Settings.Default.SciezkaPrzestrzeni;
            
            txtServerIP.Text = EFS.Properties.Settings.Default.ServerIP;
            txtClientIP.Text = EFS.Properties.Settings.Default.ClientIP;
            numPort.Value = EFS.Properties.Settings.Default.Port;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                EFS.Properties.Settings.Default.SciezkaPrzestrzeni = fbd.SelectedPath;
                EFS.Properties.Settings.Default.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string NazwaHosta = Dns.GetHostName();
            IPHostEntry AdresyIP = Dns.GetHostEntry(NazwaHosta);
            
            string ips = "";
            int licznik = 0;

            foreach (IPAddress AdresIP in AdresyIP.AddressList)
            {
                if (AdresIP.ToString() == "127.0.0.1")
                    MessageBox.Show("Komputer nie jest podłączony do sieci. AdresIP: " + AdresIP.ToString());

                else
                    
                    ips += "IP#" + ++licznik + ": " + AdresIP.ToString() + Environment.NewLine;
             
            }

            ipDisplay frm = new ipDisplay(ips);
            frm.Show();
            //MessageBox.Show(ips, "Adresy IP tego komputera");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int port = (int)numPort.Value;
            bool isOpoen = true;


            try
            {
                TcpListener server = new TcpListener(IPAddress.Loopback, port);
                server.Start();
                server.Stop();
            }
            catch
            {
                MessageBox.Show("Port " + port.ToString() + " jest zamknięty");
                isOpoen = false;

            }

            if (isOpoen)
                MessageBox.Show("Port " + port.ToString() + " jest otwarty");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EFS.Properties.Settings.Default.ServerIP = txtServerIP.Text ;
            EFS.Properties.Settings.Default.ClientIP = txtClientIP.Text;
            EFS.Properties.Settings.Default.Port = (int)numPort.Value;
            EFS.Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
