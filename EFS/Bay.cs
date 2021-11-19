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

using System.Net;
using System.Net.Sockets;

using System.Runtime.Serialization.Formatters.Binary;

// wymagane do OCR
//using Windows.ApplicationModel;
//using Windows.Globalization;
//using Windows.Graphics.Imaging;
//using Windows.UI.Xaml.Controls;
//using Windows.Media.Ocr;

namespace EFS
{
    public partial class Bay : Form
    {

        private List<Strip> _usunietePaski = new List<Strip>();
        private List<Strip> _paski = new List<Strip>();
        private enum WorkModes { Normal, TWR, GND } // normal, twr, gnd
        private WorkModes WorkMode = WorkModes.Normal;
        //public Cwiczenie m_cwiczenie;
        private Bin smietnik;
        TwrArrList twrArr;
        Bin frmBin;

        public static List<string> Runways;
        public static List<SID> SIDs;

        public static string ArrRwy;
        public static string DepRwy;

        static public Cwiczenie Exercise;

        private TimeSpan ctotUpdateChecker;

        public static DateTime czasCwiczenia;
        public static string ATIS;

        public List<State> ArrState;
        public List<State> DepState;

        private PictureBox pbStripDropIndicator;

        //public string ATISS
        //{
        //    get { return ATIS; }
        //}

        // ToDo Automatyczna synchronizacja czasu z zegarkiem BEST
        // najpierw zlap screenshota na ktorym bedzie zegarek http://stackoverflow.com/questions/5049122/capture-the-screen-shot-using-net
        // potem wrzuc w ocr - https://msdn.microsoft.com/en-us/library/windows/apps/windows.media.ocr?cs-save-lang=1&cs-lang=csharp#code-snippet-2
        // ...
        // profit

        public Bay()
        {
            //dzieki parametrowi moge wrzucac inne formy do tej
            //this.IsMdiContainer = true;

            //smietnik = new Bin(_usunietePaski);

            InitializeComponent();

            //foreach (Strip efs2 in pendingDepBay.Controls)
            //{
            //    efs2.MouseDown += efs_MouseDown;
            //}

            

            pendingDepBay.AllowDrop = true;
            taxiBay.AllowDrop = true;
            airborneBay.AllowDrop = true;
            beforeTaxiBay.AllowDrop = true;
            btnPdg.AllowDrop = true;

            this.pendingDepBay.DragEnter += new DragEventHandler(flowPanel_DragEnter);
            this.pendingDepBay.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            
            this.taxiBay.DragEnter += new DragEventHandler(flowPanel_DragEnter);
            this.taxiBay.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            
            this.rwyBay.DragEnter += new DragEventHandler(flowPanel_DragEnter);
            this.rwyBay.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            
            this.airborneBay.DragEnter += new DragEventHandler(flowPanel_DragEnter);
            this.airborneBay.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            
            this.beforeTaxiBay.DragEnter += new DragEventHandler(flowPanel_DragEnter);
            this.beforeTaxiBay.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            
            this.bin.DragEnter += new DragEventHandler(kosz_DragEnter);
            this.bin.DragDrop += new DragEventHandler(kosz_DragDrop);

            this.btnPdg.DragEnter += btnPdg_DragEnter;
            this.btnPdg.DragDrop += btnPdg_DragDrop;

            //this.btnTwrGnd.DragEnter += 


            pbStripDropIndicator = new PictureBox();
            pbStripDropIndicator.Image = EFS.Properties.Resources.StripDropIndicator;
            pbStripDropIndicator.Location = new Point(300, 400);
            pbStripDropIndicator.Visible = false;
            pbStripDropIndicator.BackColor = Color.Transparent;
            pbStripDropIndicator.Size = new Size(456, 8);
            
            this.Controls.Add(pbStripDropIndicator);
            pbStripDropIndicator.BringToFront();



        }

        void btnPdg_DragDrop(object sender, DragEventArgs e)
        {
            Strip pasek = (Strip)e.Data.GetData(typeof(Strip));
            FlowLayoutPanel pnl = (FlowLayoutPanel)pasek.Parent;

            if (pasek.TypEFS == Strip.TypPaska.ARR)
            { 
                StripSmall pasekSmall = new StripSmall(pasek);
                twrArr.AddSmallStrip(pasekSmall);
                pnl.Controls.Remove(pasek);
            }
        }
        void btnPdg_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }
        private void kosz_DragDrop(object sender, DragEventArgs e)
        {
            Strip smiec = (Strip)e.Data.GetData(typeof(Strip));

            
            smiec.UsunieteZ = (FlowLayoutPanel)smiec.Parent;

            smiec.Parent.Controls.Remove(smiec);

            frmBin.AddSmallStrip(new StripSmall(smiec));
        }
        private void kosz_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void flowPanel_DragDrop(object sender, DragEventArgs e)
        {
            Strip data = (Strip)e.Data.GetData(typeof(Strip));
            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

            if (_source != _destination)
            {
                // Add control to panel

                _destination.Controls.Add(data);

                // Reorder
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);
                _destination.Controls.SetChildIndex(data, index);

                // Invalidate to paint!
                _destination.Invalidate();
                _source.Invalidate();
            }
            else
            {
                // Just add the control to the new panel.
                // No need to remove from the other panel, this changes the Control.Parent property.
                Point p = _destination.PointToClient(new Point(e.X, e.Y));
                var item = _destination.GetChildAtPoint(p);
                int index = _destination.Controls.GetChildIndex(item, false);

                bardzoWaznaZmienna2 = index;

                _destination.Controls.SetChildIndex(data, index);
                _destination.Invalidate();
            }

            if (pbStripDropIndicator.Visible)
                pbStripDropIndicator.Visible = false;

            if (data.TypEFS == Strip.TypPaska.ARR)
                data.m_colorArrRectCallsign = data.m_tempColor;
            else if (data.TypEFS == Strip.TypPaska.DEP)
                data.m_colorDepRectCallsign = data.m_tempColor;

            //MessageBox.Show(String.Format("Mial byc indeks {0} a wyszedl {1}", bardzoWaznaZmienna1, bardzoWaznaZmienna2));
        }
        private void flowPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void efs_MouseDown(object sender, MouseEventArgs e)
        {
            Strip efs = (Strip)sender;
            efs.HighlightWhileDragging();
            DoDragDrop(efs, DragDropEffects.Move);
        }

        private void bin_Click(object sender, EventArgs e)
        {
            frmBin.Show();
        }
        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wczytaj wcz = new Wczytaj();
            //Strip efs;

            wcz.ShowDialog();

            if (wcz.DialogResult == DialogResult.OK)
            {
                //czyszcze kosz po ewentualnych pozostalosciach z poprzedniego cwiczenia
                _usunietePaski.Clear();
                

                //czyszcze beje
                
                pendingDepBay.Controls.Clear();
                rwyBay.Controls.Clear();
                taxiBay.Controls.Clear();
                airborneBay.Controls.Clear();
                beforeTaxiBay.Controls.Clear();
                twrArr.ClearList();
                frmBin.ClearList();

                Exercise = new Cwiczenie(wcz.nazwaCwiczenia, File.ReadAllText(wcz.sciezkaCwiczenia), File.ReadAllText(wcz.dapFilePath), File.ReadAllText(wcz.datFilePath));
                Exercise.ProcessBkFile(wcz.bkFilePath);

                konfiguracjaRwyToolStripMenuItem.Enabled = true;

                //ustawiam atis
                ATIS = wcz.ATIS;

                //ustawiam godzine startu cwiczenia

                Runways = Exercise.Runways;
                SIDs = Exercise.SIDs;
                czasCwiczenia = Exercise.CzasStartu;

                Exercise.RwyDep = Bay.DepRwy;
                Exercise.RwyArr = Bay.ArrRwy;
                // dodaje kilka lat ktorych na zegarku i tak nie widac, a dzieki temu user moze cofnac czas przed godzine zero
                // 
                czasCwiczenia = czasCwiczenia.AddYears(5);

                lblCzas.Text = Exercise.CzasStartu.ToLongTimeString();
                pnlCzas.Enabled = true;

                this.Text = "EFS " + wcz.nazwaCwiczenia;

                List<Strip> notSortedArr = new List<Strip>();
                List<Strip> notSortedDep = new List<Strip>();

                foreach (FlightPlan fpl in Exercise.PlanyLotu)
                {                                               //tymczasowe
                    if (fpl.FltType == FlightPlan.TypLotu.Arr || fpl.FltType == FlightPlan.TypLotu.Overflight)
                        notSortedArr.Add(new Strip(fpl));
                    else if (fpl.FltType == FlightPlan.TypLotu.Dep)
                        notSortedDep.Add(new Strip(fpl));
                }

                List<Strip> sortedArr = notSortedArr.OrderBy(o => o.m_eobt).ToList();
                List<Strip> sortedDep = notSortedDep.OrderBy(o => o.m_eobt).ToList();

                

                // ToDo: tu bedzie kod ustawiajacy poczatkowy stan cwiczenia - niektore samoloty ctl, niektore kolujace itp

                // przed wykonaniem PopulateArrList wybieram z sortedArr wszystkie paski ktore wymagaja akcji

                // NAZWY BEJÓW:
                // pendingDepBay
                // airborneBay
                // rwyBay
                // taxiBay
                // beforeTaxiBay


                try // na razie zakladam tylko jeden blad - brak pliku .bks - w tym wypadku blok TRY zostanie pominiety a wszystkie paski wyladuja w PendingDep/TwrArrList
                {
                    ArrState = new List<State>();
                    DepState = new List<State>();

                    readStateFile(wcz.sciezkaCwiczenia);

                    setDepartureState(ref sortedDep, DepState);
                    setArrivalState(ref sortedArr, ArrState);

                }
                catch (Exception ex)
                {
                    
                }

                twrArr.PopulateArrList(sortedArr);

                foreach (Strip sortedEfs in sortedDep)
                {   
                    pendingDepBay.Controls.Add(sortedEfs);
                }
            }
        }
        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ustawienia ust = new Ustawienia();
            ust.ShowDialog();
        }
        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult czyWyjsc = MessageBox.Show("Czy na pewno chcesz wyjść?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (czyWyjsc == DialogResult.OK)
                this.Close();
        }
        private void dodajPasekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DodajPasek okno = new DodajPasek();
            okno.FormClosing += new FormClosingEventHandler(obsluzDodaniePaska);
            okno.Show();
        }
        private void konfiguracjaRwyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveRunway frmAR = new ActiveRunway(Runways);
            frmAR.ShowDialog();

            DepRwy = frmAR.DepRwy;
            ArrRwy = frmAR.ArrRwy;

            //todo dla kazdego paska w pending dep zmien sid i rwy

            foreach (Strip str in pendingDepBay.Controls)
            {
                str.SelectedRunway = frmAR.DepRwy;
            }


        }
        private void btnPdg_Click(object sender, EventArgs e)
        {
            //if (twrArr == null)
            twrArr.Show();
        }

        private void readStateFile(string path)
        {
            path = path.Remove(path.Length - 4);
            path += (".bks");

            string stateFile = File.ReadAllText(path);
            //MessageBox.Show(stateFile);

            List<string> chunks = new List<string>();

            StringReader sr = new StringReader(stateFile);
            string line;


            while ((line = sr.ReadLine()) != null)
            {
                if (!line.StartsWith("//"))
                    chunks.Add(line);
            }

            foreach (string str in chunks)
            {
                if (str.StartsWith("ARR"))
                    ArrState.Add(new State(str));
                else if (str.StartsWith("DEP"))
                    DepState.Add(new State(str));
            }
        }
        private void setArrivalState(ref List<Strip> sortedArr, List<State> arrState)
        {
            for (int i = sortedArr.Count - 1; i >= 0; i--)
            {
                foreach (State state in arrState)
                {
                    if (sortedArr[i].Callsign == state.Callsign)
                    {
                        switch (state.Phase)
                        {
                            case "CONTINUE":
                                airborneBay.Controls.Add(sortedArr[i]);
                                
                                sortedArr[i].pbContApp.Visible = true;
                                break;
                            case "CLEARLAND":
                                airborneBay.Controls.Add(sortedArr[i]);
                                sortedArr[i].pbLand.Visible = true;
                                break;
                            case "LANDED":
                                rwyBay.Controls.Add(sortedArr[i]);
                                sortedArr[i].pbLand.Visible = true;
                                break;
                            
                            default:
                                break;
                        }
                    }
                }
            }

            //teraz usuwam modyfikowane z podstawowej listy zeby ne przestawilo ich na pendingDepBay

            for (int i = sortedArr.Count - 1; i >= 0; i--)
            {
                foreach (State state in arrState)
                {
                    if (sortedArr[i].Callsign == state.Callsign)
                    {
                        sortedArr.RemoveAt(i);
                    }
                }
            }
        }
        private void setDepartureState(ref List<Strip> sortedDep, List<State> depState)
        {
            //najpierw dostosowuje pola na paskach
            //for (int i = sortedDep.Count - 1; i >= 0; i--)
            for (int i = 0; i < sortedDep.Count; i++)
            {
                foreach (State state in depState)
                {
                    if (sortedDep[i].Callsign == state.Callsign)
                    {
                        switch (state.Phase)
                        {
                            case "TAXI":
                                taxiBay.Controls.Add(sortedDep[i]);
                                break;
                            case "STARTUP":
                                beforeTaxiBay.Controls.Add(sortedDep[i]);
                                break;
                            case "PUSHBACK":
                                taxiBay.Controls.Add(sortedDep[i]);
                                break;
                            case "RUNWAY": //podobno zaden samolot nie zaczyna na pasie, ale juz zrobilem, wiec nie bede kasowac ;)
                                rwyBay.Controls.Add(sortedDep[i]);
                                break;
                            case "CLRTIME":
                                sortedDep[i].m_clearanceTime = state.Param;
                                break;
                            case "STARTUPTIME":
                                sortedDep[i].m_startupTime = state.Param;
                                break;
                            //case "TAXITIME":
                            //    sortedDep[i].m_pushbackTime = state.Param;
                            //    break;
                            //    // w programie m_pushBackTime przechowuje czas w ktorym samolot zajal pole manewrowe
                                // jesli A/C rusza z standu np EPWA 37 to zajmuje pole manewrowe przez kolowanie, a nie pushback, stad powyzsze
                                // TAXITIME przypisane do zmiennej m_pushBackTime
                            case "STAND":
                                sortedDep[i].m_startPos = state.Param;
                                // to nie blad, do standu przypisuje state.Time, bo w tej zmiennej przy fazie stand przekazuje numer standu
                                //a stand trzeba poprawiac bo gdy samolot pojawia si ena poczatku cwiczenia gdzies na drodze kolowania to 
                                //jego startpos (uznawany przez strip za stand) ma wartosc danego fixu na drodze kolowania, czyli np
                                // #JN190, D2 czy E3
                                break;
                            default:
                                //pendingDepBay.Controls.Add(sortedDep[i]);
                                break;
                        }
                    }
                }
                sortedDep[i].Invalidate();
            }

            //teraz usuwam modyfikowane z podstawowej listy zeby ne przestawilo ich na pendingDepBay

            for (int i = sortedDep.Count - 1; i >= 0; i--)
            {
                foreach (State state in depState)
                {
                    if (sortedDep[i].Callsign == state.Callsign)
                    {
                        sortedDep.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        private void obsluzDodaniePaska(object sender, FormClosingEventArgs e)
        {
            DodajPasek okno = (DodajPasek)sender;
            Strip strip = okno.efs;
            try
            {
                
                if (strip.TypEFS == Strip.TypPaska.DEP)
                    pendingDepBay.Controls.Add(strip);
                else
                    taxiBay.Controls.Add(strip);
            }
            catch (Exception)
            {

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czasCwiczenia = czasCwiczenia.AddSeconds(1f);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();

            

            // odswiezam wszystkie paski co sekunde - mega nieefektowne, ale dzieki metodzie CreateParams ponizej nic nie miga wiec zostawiam
            // http://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form

            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
                    foreach (Strip efs in C.Controls)
                    {
                        if(efs.m_ctot != "")
                            if (efs.IsSlotActionNeeded())
                                efs.Invalidate();
                    }
            }


        }
        protected override CreateParams CreateParams
        {
            //dzieki temu paski nie migaja przy odswiezaniu ich co sekunde (sprawdzam sloty)
            // http://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form

            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            // TODO autosynchronizacja - tak robic screenshota
            //Bitmap screenshot = new Bitmap(SystemInformation.VirtualScreen.Width,
            //                   SystemInformation.VirtualScreen.Height);
            //Graphics screenGraph = Graphics.FromImage(screenshot);
            //screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X,
            //                           SystemInformation.VirtualScreen.Y,
            //                           0,
            //                           0,
            //                           SystemInformation.VirtualScreen.Size,
            //                           CopyPixelOperation.SourceCopy);

            //screenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            czasCwiczenia = czasCwiczenia.AddMinutes(1);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            czasCwiczenia = czasCwiczenia.AddHours(1);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            czasCwiczenia = czasCwiczenia.AddSeconds(1);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TimeSpan godzina = new TimeSpan(1,0,0);
            czasCwiczenia = czasCwiczenia.Subtract(godzina);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            TimeSpan minuta = new TimeSpan(0, 1, 0);
            czasCwiczenia = czasCwiczenia.Subtract(minuta);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            TimeSpan sekunda = new TimeSpan(0, 0, 1);
            czasCwiczenia = czasCwiczenia.Subtract(sekunda);
            lblCzas.Text = czasCwiczenia.ToLongTimeString();
        }

        private void Bay_Load(object sender, EventArgs e)
        {

            this.Height = SystemInformation.VirtualScreen.Height - 35;
            this.Location = new Point(this.Location.X, 0);


            twrArr = new TwrArrList();
            twrArr.Location = new Point(1000, 0);
            twrArr.FormaBazowa = this;
            twrArr.Show();

            frmBin = new Bin();
            frmBin.FormaBazowa = this;
            frmBin.Location = new Point(1000, 500);

            //ustawiam jeszcze raz wielkosc przy ladowaniu formy, bez tego wpisu taxiBay ma za duza wysokosc i nie bardzo wiem jak to zmienic
            taxiBay.Height = pnlTaxiSeparator.Location.Y - pnlRunwaySeparator.Location.Y - 17;


        }

        private void pnlAirborneSeparator_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point pozycja = this.PointToClient(Cursor.Position);

                if (pozycja.Y > 40 && pozycja.Y < pnlRunwaySeparator.Location.Y - 40)
                {   
                    pnlAirborneSeparator.Location = new Point(pnlAirborneSeparator.Location.X, pozycja.Y);
                    airborneBay.Height = pnlAirborneSeparator.Location.Y - 28;
                    
                    rwyBay.Location = new Point(rwyBay.Location.X, airborneBay.Location.Y + airborneBay.Height + 17);
                    rwyBay.Height = pnlRunwaySeparator.Location.Y - pnlAirborneSeparator.Location.Y - 17;
                }
            }
        }
        private void pnlRunwaySeparator_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point pozycja = this.PointToClient(Cursor.Position);
                

                if (pozycja.Y < pnlTaxiSeparator.Location.Y - 70 && pozycja.Y > pnlAirborneSeparator.Location.Y + 40)
                {
                    pnlRunwaySeparator.Location = new Point(pnlRunwaySeparator.Location.X, pozycja.Y);
                    taxiBay.Location = new Point(taxiBay.Location.X, pozycja.Y + 16);
                    rwyBay.Height = pozycja.Y - rwyBay.Location.Y - 1;
                    
                    //test
                    // oryginalny dobry wpis: taxiBay.Height = this.Height - pozycja.Y - 60;
                    //taxiBay.Height = this.Height - pozycja.Y - 60;

                    taxiBay.Height = pnlTaxiSeparator.Location.Y - pnlRunwaySeparator.Location.Y - 17;
                    //rwyBay.Location = new Point(rwyBay.Location.X, airborneBay.Location.Y + airborneBay.Height + 17);
                    //rwyBay.Height = pnlRunwaySeparator.Location.Y - pnlAirborneSeparator.Location.Y - 17;
                }
            }
        }
        private void pnlTaxiSeparator_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point pozycja = this.PointToClient(Cursor.Position);


                if (pozycja.Y < this.Size.Height - 120 && pozycja.Y > pnlRunwaySeparator.Location.Y + 40)
                {
                    pnlTaxiSeparator.Location = new Point(pnlTaxiSeparator.Location.X, pozycja.Y);
                    beforeTaxiBay.Location = new Point(beforeTaxiBay.Location.X, pozycja.Y + 16);
                    taxiBay.Height = pozycja.Y - taxiBay.Location.Y - 1;
                    beforeTaxiBay.Height = this.Height - pozycja.Y - 60;
                }
            }
        }

        private void rwyBay_ControlAdded(object sender, ControlEventArgs e)
        {
            Strip efs = (Strip)e.Control;
            if (efs.TypEFS == Strip.TypPaska.DEP)
            {
                efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                efs.m_colorDepRectTime = Color.LimeGreen;
                efs.Update();
                efs.m_airborneTime = efs.m_time;
            }
            else if (efs.TypEFS == Strip.TypPaska.ARR)
            {
                efs.m_colorArrRectEobtEta = Color.Lime;
                efs.m_eobt = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                efs.Update();
            }
            
        }
        private void airborneBay_ControlAdded(object sender, ControlEventArgs e)
        {
            Strip efs = (Strip)e.Control;
            if (efs.TypEFS == Strip.TypPaska.DEP)
            {
                efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                efs.m_colorDepRectTime = Color.DeepSkyBlue;
                efs.Update();
                efs.m_airborneTime = efs.m_time;
            }
        }
        private void BeforeTaxiBay_ControlAdded(object sender, ControlEventArgs e)
        {
            Strip efs = (Strip)e.Control;

            if (efs.TypEFS == Strip.TypPaska.DEP)
            {
                if (efs.m_colorDepRectTime == Color.LightBlue || efs.m_colorDepRectTime == Color.White)
                {
                    efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");


                    efs.m_colorDepRectTime = Color.LightGreen;
                    //efs.m_clearanceTime = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                    efs.m_startupTime = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");

                    efs.Update();
                }

            }
        }
        private void taxiBay_ControlAdded(object sender, ControlEventArgs e)
        {
            Strip efs = (Strip)e.Control;
            if (efs.TypEFS == Strip.TypPaska.DEP)
            {
                if (efs.m_pushbackTime == "" && efs.m_colorDepRectTime != Color.LimeGreen)
                {
                    efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                    efs.m_colorDepRectTime = Color.LimeGreen;
                    efs.Update();
                    efs.m_pushbackTime = efs.m_time;
                }
            }
        }

        public void addArrStrip(Strip efs)
        {
            Strip efss = efs;
            efss.SelectedRunway = Bay.ArrRwy;
            
            airborneBay.Controls.Add(efss);
            airborneBay.Controls.SetChildIndex(efss, 0);
        }

        private void btnObstSymb_Click(object sender, EventArgs e)
        {
            AddObstacleStrip frmAddObstacleStrip = new AddObstacleStrip();
            frmAddObstacleStrip.FormClosing += frmAddObstacleStrip_FormClosing;
            frmAddObstacleStrip.Show();
        }
        void frmAddObstacleStrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddObstacleStrip x = (AddObstacleStrip)sender;
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                this.pendingDepBay.Controls.Add(x.strip);
            
        }
        private void btnLocalEFS_Click(object sender, EventArgs e)
        {
            AddLocalEFS frmAddLocalEFS = new AddLocalEFS();
            frmAddLocalEFS.FormClosing += frmAddLocalEFS_FormClosing;
            frmAddLocalEFS.Show();
        }
        void frmAddLocalEFS_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddLocalEFS x = (AddLocalEFS)sender;
            if (x.localEfsType == "dep")
            {
                x.strip.TypEFS = Strip.TypPaska.LocalEFSDep;
                pendingDepBay.Controls.Add(x.strip);
            }
            else if (x.localEfsType == "arr")
            {
                x.strip.TypEFS = Strip.TypPaska.LocalEFSArr;
                airborneBay.Controls.Add(x.strip);
            }
        }

        // net comm methods

        TcpListener server;
        TcpClient client;
        IPAddress ipAddress;
        BinaryReader reader;
        BinaryWriter writer;
        NetworkStream ns;
        bool connectionActive = false;

        private delegate void TextUpdate(string text);
        private delegate void ControlAdded(string strip);
        private delegate void UpdateControl(bool active);

        private void btnNetStart_Click(object sender, EventArgs e)
        {
            if (radTwr.Checked)
            {
                backgroundWorker1.RunWorkerAsync();
                WorkMode = WorkModes.TWR;
                btnNetStart.Enabled = false;
                btnNetStop.Enabled = true;
                radTwr.Enabled = false;
                radGnd.Enabled = false;
                InterfaceSetup(WorkMode);
            }
            else if (radGnd.Checked)
            {
                backgroundWorker3.RunWorkerAsync();
                WorkMode = WorkModes.GND;
                btnNetStart.Enabled = false;
                btnNetStop.Enabled = true;
                radTwr.Enabled = false;
                radGnd.Enabled = false;
                InterfaceSetup(WorkMode);
            }
            else
            {
                MessageBox.Show("Wybierz TWR lub GND", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
        private void btnNetStop_Click(object sender, EventArgs e)
        {
            try
            {
                writer.Write("###DISCONNECT###");
            }
            catch
            {
                StatusUpdate("No connection established");
            }

            if (radTwr.Checked)
            {
                server.Stop();
                btnNetStart.Enabled = true;
                btnNetStop.Enabled = false;
                radTwr.Enabled = true;
                radGnd.Enabled = true;
            }
            else if (radGnd.Checked)
            {
                try
                {
                    client.Close();
                }
                catch { }
                
                btnNetStart.Enabled = true;
                btnNetStop.Enabled = false;
                radTwr.Enabled = true;
                radGnd.Enabled = true;
            }

            connectionActive = false;
            InterfaceSetup(WorkModes.Normal);
        }

        private void InterfaceSetup(WorkModes WorkMode)
        {
            switch (WorkMode)
            {
                case WorkModes.Normal:
                    btnTwrGnd.Visible = false;
                    pendingDepBay.Visible = true;
                    btnPdg.Enabled = true;
                    twrArr.Show();
                    break;
                case WorkModes.GND:
                    btnTwrGnd.Visible = true;
                    btnTwrGnd.Text = "TWR";
                    pendingDepBay.Visible = true;
                    btnPdg.Enabled = false;
                    twrArr.Hide();
                    
                    break;
                case WorkModes.TWR:
                    pendingDepBay.Visible = false;
                    btnTwrGnd.Visible = true;
                    btnTwrGnd.Text = "GND";

                    btnPdg.Enabled = true;
                    twrArr.Show();
                    
                    break;
            }
        }

        private void StripAdded(string initValue)
        {
            Strip toAdd;

            string[] inits = initValue.Split(';');

            toAdd = new Strip(Exercise.GetFlightPlan(inits[0]));
            toAdd.ProcessInitString(inits);


            if (taxiBay.InvokeRequired)
            {
                ControlAdded f = new ControlAdded(StripAdded);
                this.Invoke(f, new object[] { initValue });
            }
            else
            {
                if (WorkMode == WorkModes.GND)
                {
                    taxiBay.Controls.Add(toAdd); // pasek od twr dla gnd pojawi sie na gorze taxiBay
                    taxiBay.Controls.SetChildIndex(toAdd, 0);
                }
                else
                    taxiBay.Controls.Add(toAdd); // pasek od gnd dla twr pojawia sie na dole taxiBay, nie trzeba nic modyfikowac

            }
            
        }
        private void StatusUpdate(string text)
        {
            if (listBox1.InvokeRequired)
            {
                TextUpdate f = new TextUpdate(StatusUpdate);
                this.Invoke(f, new object[] { text });
            }
            else
                listBox1.Items.Add(text);
        }

        private void radGndEnabledUpdate(bool state)
        {
            if (radGnd.InvokeRequired)
            {
                UpdateControl f = new UpdateControl(radGndEnabledUpdate);
                this.Invoke(f, new object[] { state });
            }
            else
                radGnd.Enabled = state;
        }
        private void radTwrEnabledUpdate(bool state)
        {
            if (radTwr.InvokeRequired)
            {
                UpdateControl f = new UpdateControl(radTwrEnabledUpdate);
                this.Invoke(f, new object[] { state });
            }
            else
                radTwr.Enabled = state;
        }
        private void btnNetStartEnabledUpdate(bool state)
        {
            if (btnNetStart.InvokeRequired)
            {
                UpdateControl f = new UpdateControl(btnNetStartEnabledUpdate);
                this.Invoke(f, new object[] { state });
            }
            else
                btnNetStart.Enabled = state;
        }
        private void btnNetStopEnabledUpdate(bool state)
        {
            if (btnNetStop.InvokeRequired)
            {
                UpdateControl f = new UpdateControl(btnNetStopEnabledUpdate);
                this.Invoke(f, new object[] { state });
            }
            else
                btnNetStop.Enabled = state;
        }

        private void btnTwrGnd_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void btnTwrGnd_DragDrop(object sender, DragEventArgs e)
        {
            Strip efs = (Strip)e.Data.GetData(typeof(Strip));
           
            if (connectionActive)
            {
                writer.Write(efs.GenerateInitString());
                efs.Dispose();
            }
            else
                MessageBox.Show("Brak połączenia!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StatusUpdate("TWR started");

            int port = EFS.Properties.Settings.Default.Port;
            ipAddress = IPAddress.Parse(EFS.Properties.Settings.Default.ServerIP);
            

            try
            {
                server = new TcpListener(ipAddress, port);
                server.Start();


                StatusUpdate("Awaiting GND connection... from " + EFS.Properties.Settings.Default.ClientIP);
                StatusUpdate("server ip is " + EFS.Properties.Settings.Default.ServerIP);

                client = server.AcceptTcpClient();
                

                connectionActive = true;

                ns = client.GetStream();

                reader = new BinaryReader(ns);
                writer = new BinaryWriter(ns);

                backgroundWorker2.RunWorkerAsync();
            }
            catch 
            {
                
            }

        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            StatusUpdate("GND connected");
            string msg;

            try
            {
                while (connectionActive)
                {
                    msg = reader.ReadString();

                    if (msg == "###DISCONNECT###")
                    {
                        connectionActive = false;
                        StatusUpdate("GND disconnected");

                        radGndEnabledUpdate(true);
                        radTwrEnabledUpdate(true);

                        btnNetStartEnabledUpdate(true);
                        btnNetStopEnabledUpdate(false);

                        server.Stop();
                    }
                    else
                    {
                        StatusUpdate(msg);
                        StripAdded(msg);
                    }
                }
            }
            catch
            {
                StatusUpdate("TWR stopped");
            }
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StatusUpdate("Starting GND");

                int port = EFS.Properties.Settings.Default.Port;
                string ip = EFS.Properties.Settings.Default.ServerIP;

                StatusUpdate("Trying to connect to TWR on " + EFS.Properties.Settings.Default.ServerIP);
                StatusUpdate("client ip is " + EFS.Properties.Settings.Default.ClientIP);
                client = new TcpClient(ip, port);

                ns = client.GetStream();

                writer = new BinaryWriter(ns);
                reader = new BinaryReader(ns);

                //writer.Write("czesc");

                backgroundWorker4.RunWorkerAsync();
                connectionActive = true;
            }
            catch
            {
             

            }
        }
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg;
            StatusUpdate("Connected to TWR");
            
            try
            {
                while (connectionActive)
                {
                    msg = reader.ReadString();

                    if (msg == "###DISCONNECT###")
                    {
                        connectionActive = false;

                        radGndEnabledUpdate(true);
                        radTwrEnabledUpdate(true);

                        btnNetStartEnabledUpdate(true);
                        btnNetStopEnabledUpdate(false);
                    }
                    else
                    {
                        StatusUpdate(msg);
                        StripAdded(msg);
                    }
                    
                }
                StatusUpdate("TWR disconnected");
                client.Close();
            }
            catch
            {
                
            }
        }

        int bardzoWaznaZmienna1 = -1;
        int bardzoWaznaZmienna2 = -1;


        private void bay_DragOver(object sender, DragEventArgs e)
        {

            #region tu schowana gruba rozkmina co dziala, ale nie zawsze do konca dobrze :)
            //FlowLayoutPanel flp = (FlowLayoutPanel)sender;
            //Point pt;

            //Strip currentStrip = (Strip)e.Data.GetData(typeof(Strip));



            //pt = flp.PointToClient(new Point(e.X, e.Y));
            
            //try
            //{
            //    object x = flp.GetChildAtPoint(pt);

            //    if ((Strip)x == currentStrip) //jesli nie wyszedlem poza obreb paska ktory chce przeciagnac to nic nie robie
            //    {
            //        listBox1.Items.Add("Ten sam");
            //        pbStripDropIndicator.Visible = false;
            //        return;
            //    }

            //    int size = CalculateItemsSize(flp);

            //    ////////////////////////////////
            //    //  gdy nie ma innych paskow
            //    ////////////////////////////////
            //    listBox1.Items.Add(currentStrip.Location.ToString());

            //    if (flp.Controls.Count == 0 && flp.FlowDirection == FlowDirection.TopDown)
            //    {
            //        pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y);
            //        pbStripDropIndicator.Visible = true;
            //    }
            //    else if (flp.Controls.Count == 0 && flp.FlowDirection == FlowDirection.BottomUp)
            //    {
            //        pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + flp.Height - 8);
            //        pbStripDropIndicator.Visible = true;
            //    }
            //    /////////////////////////////////////////////
            //    //      gdy sortowanie z gory do dolu
            //    /////////////////////////////////////////////
            //    else if (flp.Controls.Count != 0 && flp.FlowDirection == FlowDirection.TopDown)
            //    {
            //        if (x is Strip)
            //        {
                        
            //            Strip str = (Strip)x;

            //            if (str.Parent != currentStrip.Parent)
            //                listBox1.Items.Add("rozne flp");
            //            else
            //                listBox1.Items.Add("te same flp");


            //            //zrob z podzialem na testc same/rozne flp - // gdy te same to trzeba obslugiwac sprawdzenie czy rpzesuwam w dol czy w gore
            //            //                                            // gdy rozne to trzeba obslugiwac bez wyjatkow
            //            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                

            //            if (str.Location.Y < currentStrip.Location.Y) //inne zachowanie gdy przeciagam pasek w gore listy
            //            {
            //                pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + str.Location.Y - 6);
            //                pbStripDropIndicator.Visible = true;
            //            }
            //            else // a inne gdy przeciagam w dol - tu byly problemy z pozycja DropIndicatora vs miejscem gdzie faktycznie wstawialo pasek
            //            {
            //                pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + str.Location.Y + str.Height - 0);
            //                pbStripDropIndicator.Visible = true;
            //            }
                        
            //        }
            //        else if (!(x is Strip) && pt.Y > size)   // wyswietlam DropIndicator na samym koncu i zapobiegam miganiu 
            //        {
            //            pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + size - 2);
            //            pbStripDropIndicator.Visible = true;
            //        }
            //    }
            //    /////////////////////////////////////////////
            //    //      gdy sortowanie z dolu do gory
            //    /////////////////////////////////////////////
            //    else if (flp.Controls.Count != 0 && flp.FlowDirection == FlowDirection.BottomUp)
            //    {
            //        if (x is Strip)
            //        {
            //            Strip str = (Strip)x;

            //            if (str.Location.Y < currentStrip.Location.Y) //inne zachowanie gdy przeciagam pasek w gore listy
            //            {
            //                pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + str.Location.Y - 6);
            //                pbStripDropIndicator.Visible = true;
            //            }
            //            else // a inne gdy przeciagam w dol - tu byly problemy z pozycja DropIndicatora vs miejscem gdzie faktycznie wstawialo pasek
            //            {
            //                pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + str.Location.Y + str.Height);
            //                pbStripDropIndicator.Visible = true;
            //            }
            //        }
            //        else if (!(x is Strip) && pt.Y < flp.Height - size) //wyswietlam DropIndicator na samej gorze beja z paskami i zapobiegam miganiu
            //        {
            //            pbStripDropIndicator.Location = new Point(flp.Location.X + 1, flp.Location.Y + flp.Height - size - 6);
            //            pbStripDropIndicator.Visible = true;
            //        }
            //    }   
            //}
            //catch
            //{

            //}
            #endregion 

            FlowLayoutPanel parent = (FlowLayoutPanel)sender;
            

            Point pt = parent.PointToClient(new Point(e.X, e.Y));
            Strip str = (Strip)parent.GetChildAtPoint(pt);
            
            try
            {
                bardzoWaznaZmienna1 = parent.Controls.GetChildIndex(str);
            }

            catch
            {
            }

            //listBox1.Items.Add("dodam kontrolke w indeksie " + bardzoWaznaZmienna1.ToString());


            //przewijam listbox 
            
            listBox1.TopIndex = listBox1.Items.Count - 1;

        }

        private int CalculateItemsSize(FlowLayoutPanel flp)
        {
            int size = 0;
            foreach (Control ctl in flp.Controls)
            {
                size += ctl.Size.Height + ctl.Margin.Bottom + 3;
            }
            return size;
        }

        private void bay_DragLeave(object sender, EventArgs e)
        {
            pbStripDropIndicator.Visible = false;
        }
    }

    public struct State
    {
        public string ArrDep;
        public string Callsign;
        public string Phase;
        public string Param;


        public State(string arrdep, string callsign, string phase, string param)
        {
            ArrDep = arrdep;
            Callsign = callsign;
            Phase = phase;
            Param = null;

        }

        public State(string fullLine)
        {
            string[] temp = fullLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            ArrDep = temp[0];
            Callsign = temp[1];
            Phase = temp[2];
            if (temp.Length == 3)
                Param = null;
            else
                Param = temp[3];
        }
    }
}


// tu niech bedzie moj notatnik na pomysly:

//todo w folderze przestrzeni plik tekstowy z defaultowymi wartosciami dla rozwijanych menu, np taxiTo H2, A8, D2 itp, zeby kazde lotnisko mialo swoj zestaw

//todo bin wygladajacy jak pending lista

//todo ostrzezenia o niezaladowaniu plikow dat dap

//todo wsadz ladowanie cwiczenia w try {}

//todo sprobuj ulepszyc mechanizm pojedynczego klikniecia, zeby nawet przy evencie drag o mala wartosc odpalalo click.
