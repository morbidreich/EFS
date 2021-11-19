using System;
using System.IO;
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
    public partial class Wczytaj : Form
    {
        private string sciezkaPrzestrzeni;
        private List<Cwiczenie> m_cwiczenia = new List<Cwiczenie>();
        private string[] m_pliki;
        private string[] m_foldery;

        public string sciezkaCwiczenia;
        public string dapFilePath;
        public string datFilePath { get; set; }
        public string sciezkaPlikuPerf;
        public string nazwaCwiczenia;
        public string ATIS;
        public string bkFilePath { get; set; }

        public List<Cwiczenie> Cw
        {
            get { return m_cwiczenia; }
        }        
        
        public Wczytaj()
        {   
            /////////////////////////////////////
            
            InitializeComponent();
            sciezkaPrzestrzeni = EFS.Properties.Settings.Default.SciezkaPrzestrzeni + @"\";

            label1.Text = String.Format("Ścieżka: {0}", sciezkaPrzestrzeni);

            m_pliki = Directory.GetFiles(sciezkaPrzestrzeni);
            m_foldery = Directory.GetDirectories(sciezkaPrzestrzeni);
            

            string[] separator = new string[]{@"\"};

            foreach (string str in m_foldery)
            {
                string[] nazwafolderu = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                listBox1.Items.Add(nazwafolderu[nazwafolderu.Length-1]);
            }
            //foreach (string path in m_pliki)
            //{
            //    m_cwiczenia.Add(new Cwiczenie(path, File.ReadAllText(path)));
            //    listBox1.Items.Add(path);
            //}


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tu po wybraniu przestrzeni kod do wyswietlenia cwiczen w drugiej liscie

            if (listBox1.SelectedItem != null)
            {
                string[] cwiczeniaWPrzestrzeni = Directory.GetFiles(sciezkaPrzestrzeni + listBox1.SelectedItem.ToString());
                listBox2.Items.Clear();

                string[] separator = new string[] { @"\" };

                //string[] pliki = Directory.GetFiles(sciezkaPrzestrzeni + listBox1.SelectedItem.ToString()); 
                string[] nazwaCw = listBox1.SelectedItem.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);


                foreach (string str in cwiczeniaWPrzestrzeni)
                {
                    if (str.EndsWith(".dax"))
                    {
                        string[] temp = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        string nazwaPliku = temp[temp.Length - 1];
                        nazwaPliku = nazwaPliku.Substring(0, nazwaPliku.Length - 4);
                        listBox2.Items.Add(nazwaPliku);
                    }
                    else if (str.EndsWith(".dap"))
                    {
                        dapFilePath = str;
                    }
                    else if (str.EndsWith(listBox1.SelectedItem.ToString() + ".dat"))
                    {
                        datFilePath = str;
                    }
                    else if (str.EndsWith(".bk"))
                        bkFilePath = str;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string[] separator = new string[] { @"\" };
                string[] tempNazwaCwiczenia = listBox2.SelectedItem.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                string adresCwiczenia = sciezkaPrzestrzeni + listBox1.SelectedItem + @"\" + tempNazwaCwiczenia[tempNazwaCwiczenia.Length - 1] + ".dax";

                //MessageBox.Show(String.Format("Wczytuje {0}", adresCwiczenia));

                sciezkaCwiczenia = adresCwiczenia;
                ATIS = textBox1.Text;
                nazwaCwiczenia = tempNazwaCwiczenia[tempNazwaCwiczenia.Length - 1];

                Bay.ArrRwy = cmbArrRwy.SelectedItem.ToString();
                Bay.DepRwy = cmbDepRwy.SelectedItem.ToString();


                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Musisz wybrać przestrzeń i ćwiczenie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbArrRwy.Items.Clear();
            cmbDepRwy.Items.Clear();

           //mega nieefektywne, ale jeszcze raz stworz sobie instancje Cwiczenie

            string ex = File.ReadAllText(sciezkaPrzestrzeni + @"\" + listBox1.SelectedItem + @"\" + listBox2.SelectedItem.ToString() + ".dax");
            Cwiczenie temp = new Cwiczenie("x", ex, File.ReadAllText(dapFilePath), File.ReadAllText(datFilePath));

            

            foreach (string rwy in temp.Runways)
            {
                cmbArrRwy.Items.Add(rwy);
                cmbDepRwy.Items.Add(rwy);
            }

            if (cmbArrRwy.Items.Count > 0)
            {
                cmbArrRwy.SelectedIndex = cmbArrRwy.Items.Count - 1;
            }

            if (cmbDepRwy.Items.Count > 0)
            {
                cmbDepRwy.SelectedIndex = cmbDepRwy.Items.Count - 1;
            }


        }

        private void Wczytaj_Load(object sender, EventArgs e)
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);

            Point pt = new Point();

            pt.X = Cursor.Position.X;
            pt.Y = Cursor.Position.Y;

            this.Location = pt;
        }
    }
}
