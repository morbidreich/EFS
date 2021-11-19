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
    public partial class testowa : Form
    {
        List<string> DisplayArgs = new List<string>();
        public string ReturnValue { get; set; }
        Button free;
        private AddObstacleStrip fx;
        private AddLocalEFS fx2;

        Color listColor = Color.DarkTurquoise;

        public testowa(List<string> list)
        {
            InitializeComponent();
            this.DisplayArgs = list;
            this.Capture = true;
            this.BackColor = listColor;

            if (DisplayArgs != null)
            {
                foreach (string str in DisplayArgs)
                {
                    Button btn = new Button();
                    Font myFont = new Font("Arial", 8f, FontStyle.Bold);
                    btn.Text = str;
                    btn.Font = myFont;
                    btn.Padding = new Padding(1);
                    btn.Margin = new Padding(1);
                    btn.Width = 70;
                    btn.Height = 21;
                    btn.FlatAppearance.BorderColor = listColor;

                    pnlItems.Controls.Add(btn);
                }
            }

            this.Height = pnlItems.Controls.Count * 23;
            this.Width = 75;
        }

        public testowa(bool freeText, List<string> list)
        {
            InitializeComponent();
            this.DisplayArgs = list;
            this.Capture = true;
            this.BackColor = listColor;

            free = new Button();
            Font myFont = new Font("Arial", 8f, FontStyle.Bold);
            free.Font = myFont;
            free.Padding = new Padding(1);
            free.Margin = new Padding(1);
            free.Width = 70;
            free.Height = 21;
            //free.FlatStyle = FlatStyle.Flat;
            free.FlatAppearance.BorderColor = listColor;
            
            free.Text = "-free-";

            if (freeText)
                pnlItems.Controls.Add(free);

            if (list != null)
            {
                foreach (string str in DisplayArgs)
                {
                    Button btn = new Button();
                    btn.Font = myFont;
                    btn.Padding = new Padding(1);
                    btn.Margin = new Padding(1);
                    btn.Width = 70;
                    btn.Height = 21;
                    btn.Text = str;
                    //btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = listColor;
                    

                    pnlItems.Controls.Add(btn);
                }
            }

            #region ustawiam odpowiednia wielkosc ramki
            if (pnlItems.Controls.Count < 41) // 1 rzad
            {
                this.Height = pnlItems.Controls.Count * 23;
                this.Width = 75;
                //MessageBox.Show("ilosc: " + pnlItems.Controls.Count.ToString());
            }
            else if (pnlItems.Controls.Count < 81) // 2 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 2) * 23;
                this.Width = 75 * 2;
                
            }
            else if (pnlItems.Controls.Count < 121) // 3 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 3) * 23;
                this.Width = 75 * 3;
                
            }
            else if (pnlItems.Controls.Count < 161) // 4 rzedow
            {
                int h = ((pnlItems.Controls.Count / 4) + 1) * 23;
                int w = 72 * 4;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 125) // 5 rzedow
            {
                int h = ((pnlItems.Controls.Count / 5) + 1) * 23;
                int w = 72 * 5;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 150) // 6 rzedow
            {
                int h = ((pnlItems.Controls.Count / 6) + 1) * 23;
                int w = 72 * 6;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 175) // 7 rzedow
            {
                int h = ((pnlItems.Controls.Count / 7) + 1) * 23;
                int w = 72 * 7;
                this.Size = new Size(w, h);
            }
            #endregion
        }

        // w oknie AddObstacleStrip po zmianie nazwy paska z opcji -free- po wpisaniu free
        // okno AddObstacleStrip ladowalo pod glownym oknem programu. Tu dodalem sobie do niego
        // referencje zeby po dodaniu nazwy przez -free- wyciagnac je na przod 
        // frm.bringtofront
        public testowa(bool freeText, List<string> list, AddObstacleStrip frm)
        {
            InitializeComponent();
            this.DisplayArgs = list;
            this.Capture = true;
            this.fx = frm;

            free = new Button();
            Font myFont = new Font("Arial", 8f, FontStyle.Bold);
            free.Font = myFont;
            free.Padding = new Padding(1);
            free.Margin = new Padding(1);
            free.Width = 70;
            free.Height = 21;

            free.Text = "-free-";

            if (freeText)
                pnlItems.Controls.Add(free);

            if (list != null)
            {
                foreach (string str in DisplayArgs)
                {
                    Button btn = new Button();
                    btn.Font = myFont;
                    btn.Padding = new Padding(1);
                    btn.Margin = new Padding(1);
                    btn.Width = 70;
                    btn.Height = 21;
                    btn.Text = str;

                    pnlItems.Controls.Add(btn);
                }
            }

            #region ustawiam odpowiednia wielkosc ramki
            if (pnlItems.Controls.Count < 25) // 1 rzad
            {
                this.Height = pnlItems.Controls.Count * 23;
                this.Width = 75;
                //MessageBox.Show("ilosc: " + pnlItems.Controls.Count.ToString());
            }
            else if (pnlItems.Controls.Count < 50) // 2 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 2) * 23;
                this.Width = 75 * 2;

            }
            else if (pnlItems.Controls.Count < 75) // 3 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 3) * 23;
                this.Width = 75 * 3;

            }
            else if (pnlItems.Controls.Count < 100) // 4 rzedow
            {
                int h = ((pnlItems.Controls.Count / 4) + 1) * 23;
                int w = 72 * 4;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 125) // 5 rzedow
            {
                int h = ((pnlItems.Controls.Count / 5) + 1) * 23;
                int w = 72 * 5;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 150) // 6 rzedow
            {
                int h = ((pnlItems.Controls.Count / 6) + 1) * 23;
                int w = 72 * 6;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 175) // 7 rzedow
            {
                int h = ((pnlItems.Controls.Count / 7) + 1) * 23;
                int w = 72 * 7;
                this.Size = new Size(w, h);
            }
            #endregion
        }

        public testowa(bool freeText, List<string> list, AddLocalEFS frm)
        {
            InitializeComponent();
            this.DisplayArgs = list;
            this.Capture = true;
            this.fx2 = frm;

            free = new Button();
            Font myFont = new Font("Arial", 8f, FontStyle.Bold);
            free.Font = myFont;
            free.Padding = new Padding(1);
            free.Margin = new Padding(1);
            free.Width = 70;
            free.Height = 21;

            free.Text = "-free-";

            if (freeText)
                pnlItems.Controls.Add(free);

            if (list != null)
            {
                foreach (string str in DisplayArgs)
                {
                    Button btn = new Button();
                    btn.Font = myFont;
                    btn.Padding = new Padding(1);
                    btn.Margin = new Padding(1);
                    btn.Width = 70;
                    btn.Height = 21;
                    btn.Text = str;

                    pnlItems.Controls.Add(btn);
                }
            }

            #region ustawiam odpowiednia wielkosc ramki
            if (pnlItems.Controls.Count < 25) // 1 rzad
            {
                this.Height = pnlItems.Controls.Count * 23;
                this.Width = 75;
                //MessageBox.Show("ilosc: " + pnlItems.Controls.Count.ToString());
            }
            else if (pnlItems.Controls.Count < 50) // 2 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 2) * 23;
                this.Width = 75 * 2;

            }
            else if (pnlItems.Controls.Count < 75) // 3 rzedy
            {
                this.Height = (pnlItems.Controls.Count / 3) * 23;
                this.Width = 75 * 3;

            }
            else if (pnlItems.Controls.Count < 100) // 4 rzedow
            {
                int h = ((pnlItems.Controls.Count / 4) + 1) * 23;
                int w = 72 * 4;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 125) // 5 rzedow
            {
                int h = ((pnlItems.Controls.Count / 5) + 1) * 23;
                int w = 72 * 5;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 150) // 6 rzedow
            {
                int h = ((pnlItems.Controls.Count / 6) + 1) * 23;
                int w = 72 * 6;
                this.Size = new Size(w, h);
            }
            else if (pnlItems.Controls.Count < 175) // 7 rzedow
            {
                int h = ((pnlItems.Controls.Count / 7) + 1) * 23;
                int w = 72 * 7;
                this.Size = new Size(w, h);
            }
            #endregion
        }

        private void testowa_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(string.Format(("{0} {1}"), e.X, e.Y));
            try
            {
                Button x = (Button)pnlItems.GetChildAtPoint(new Point(e.X, e.Y));
                ReturnValue = x.Text;
                if (fx != null)
                    fx.BringToFront();
                if (fx2 != null)
                    fx2.BringToFront();

            }
            catch (Exception)
            {
                
            }

            this.Close();
        }

        private void testowa_Load(object sender, EventArgs e)
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);

            Point pt = new Point();

            pt.X = Cursor.Position.X - this.Width / 2;
            pt.Y = Cursor.Position.Y;

            this.Location = pt;

            //if ((this.Left + this.Width) > currentScreen.Bounds.Width)
            //    this.Left = currentScreen.Bounds.Width - this.Width;

            //if (this.Left < currentScreen.Bounds.Left)
            //    this.Left = currentScreen.Bounds.Left;

            if ((this.Top + this.Height) > currentScreen.Bounds.Height - 40)
                this.Top = currentScreen.Bounds.Height - this.Height - 40;

            if (this.Top < currentScreen.Bounds.Top)
                this.Top = currentScreen.Bounds.Top;
        }

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    this.Close();
        //    base.OnLostFocus(e);
        //}
    }
}
