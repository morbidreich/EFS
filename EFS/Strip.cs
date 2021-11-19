using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EFS
{
    [Serializable]
    public partial class Strip : Control
    {

        public enum TransponderType { N, C, S, A };
        public enum WakeTurbEnum { L, M, H, J };
        public enum TypPaska { TEST, ARR, DEP, ARRsmall, DEPsmall, Overflight, Info, LocalEFS, LocalEFSArr, LocalEFSDep }

        UpgradedPictureBox pbLineUp;
        UpgradedPictureBox pbTakeOff;
        public UpgradedPictureBox pbLand;
        public UpgradedPictureBox pbContApp;
        UpgradedPictureBox pbGoAround;
        UpgradedPictureBox pbBlank;

        System.Windows.Forms.Timer doubleClickChecker = new System.Windows.Forms.Timer();

        public FlightPlan FPL { get; set; }

        public string SelectedRunway
        {
            get { return m_rwy; }
            set { this.m_rwy = value; }
        }
        public List<string> Runways { get; set; }
        public List<SID> SIDs { get; set; }
        public bool SlotAction { get; set; }
        public bool SlotPassedToAirplane = false;

        Label lblTimes;
        TextBox txtFreeText;

        #region fields

        private bool m_extendedShown = false;
        private bool m_freeTextFilled = false;
        private bool m_isVfr = false;
        private string m_callsign = "???";
        private string m_actype = "???";
        private string m_rfl = "???";
        private string m_squawk = "???";
        private string m_route = "???";
        private string m_adep = "???";
        private string m_adest = "???";
        private string m_tas = "???";
        private string m_infoTextCenter = "";
        private string m_landState = "";
        public string m_takeoffState = "";      //potrzebuje public zeby po przeciagnieciu na rwyBay uaktualnic wpis na "L/U" TODO - dopytaj czy tak to dziala
        private string m_atis = "";
        public string m_time = "";              //potrzebuje public zeby po przeciagnieciu na airborneBay uaktualnic EOBT na biezacy czas
        public string m_startPos = "";
        private string m_arrStand = "";
        private string m_freeText = "";
        private string m_status = "";
        private string m_flightRules = "IFR";
        private string m_rwy = "";
        private string m_taxiTo = "";
        private List<SID> m_sids;
        private List<string> m_presetTaxiTo;
        private List<string> m_presetStand;
        private List<string> m_presetSid;
        private List<string> m_presetStar;
        public List<string> m_presetObstSymb;
        public List<LocalEFSData> m_presetLocalEFS;

        //pola dla paska dep:
        public string m_ctot = "";
        public string m_pushbackTime = "";
        public string m_clearanceTime = "";
        public string m_startupTime = "";
        public string m_airborneTime = "";

        public string WakeTurb { get; set; }
        
        public string m_eobt = "";
        private FlowLayoutPanel m_usunieteZ = null;
        public WakeTurbEnum m_wakeTurb = WakeTurbEnum.M;
        public string m_transType = "";
        public TypPaska TypEFS { get; set; }

        #endregion

        #region Graphics
        #region Rectangles

        Rectangle rectAtis = new Rectangle(0, 0, 20, 30);
        Rectangle rectRwy = new Rectangle(20, 0, 70, 30);
        Rectangle rectSidStar = new Rectangle(0, 30, 90, 30);
        Rectangle rectAcInfo = new Rectangle(90, 0, 70, 30);
        Rectangle rectTime = new Rectangle(90, 30, 70, 30);
        Rectangle rectEobtEta = new Rectangle(160, 0, 60, 30);
        Rectangle rectClearance = new Rectangle(160, 30, 60, 30);
        Rectangle rectCallsign = new Rectangle(220, 0, 150, 59);
        Rectangle rectCallsignAlignment = new Rectangle(220, 0, 150, 65);
        Rectangle rectTaxiTo = new Rectangle(370, 0, 60, 30);
        Rectangle rectStand = new Rectangle(370, 30, 60, 30);
        Rectangle rectHighlight = new Rectangle(429, 0, 19, 59);
        Rectangle rectFreeTextIndicator = new Rectangle(93, 3, 65, 25);
        Rectangle rectVfrIndicator = new Rectangle(3, 33, 85, 24);

        #endregion


        //to pole uzywam zeby po przeciagnieciu powrocic z brazowego do wlasciwego koloru
        public Color m_tempColor;

        //kolory kwadratow skladowych Dep
        public Color m_colorObstacle = Color.White;
        public Color m_colorDepRectCallsign = Color.LightBlue;
        public Color m_colorDepRectTime = Color.LightBlue;
        public Color m_colorDepRectEobtEta = Color.LightBlue;
        Color m_depKolor = Color.LightBlue; //         --- do wypelnienia wszystkich pol ktore nie zmieniaja koloru

        //kolory kwadratow skladowych Dep
        public Color m_colorArrRectCallsign = Color.LightYellow;
        public Color m_colorArrRectTime = Color.LightYellow;
        public Color m_colorArrRectEobtEta = Color.LightYellow;
        Color m_arrKolor = Color.LightYellow; //         --- do wypelnienia wszystkich pol ktore nie zmieniaja koloru

        //kolory akcji
        Color m_colorAtcClearance = Color.White;
        Color m_colorStartup = Color.LightGreen;
        Color m_colorPushback = Color.Lime;
        Color m_colorTakeoffTime = Color.SkyBlue;


        SolidBrush brushRectCallsigh;// = new SolidBrush(m_colorDepRectCallsign);
        SolidBrush brushRectTime;// = new SolidBrush(m_colorDepRectTime);
        SolidBrush brushRectEobtEta;// = new SolidBrush(m_colorDepRectEobtEta);
        SolidBrush brushKolor;// = new SolidBrush(m_depKolor);
        SolidBrush brushObstacle;// = new SolidBrush(m_colorObstacle);

        #endregion

        //brushe do kolorowania paskow

        private bool allowDrop = true;

        #region properties

        public FlowLayoutPanel UsunieteZ
        {
            get { return m_usunieteZ; }
            set { this.m_usunieteZ = value; }
        }
        public Color Kolor
        {
            set { m_depKolor = value; Invalidate(); }
            get { return m_depKolor; }
        }
        public string Callsign
        { 
            get {return m_callsign;} 
            set { this.m_callsign = value;} 
        }
        public string ACType
        {
            get { return m_actype; }
            set { this.m_actype = value; }
        }
        public string RFL
        {
            get { return m_rfl; }
            set { this.m_rfl = value; }
        }
        public string CFL { get; set; }
        public string Squawk
        {
            get { return m_squawk; }
            set { this.m_squawk = value; }
        }
        public string Route
        {
            get { return m_route; }
            set { this.m_route = value; }
        }
        public string ADEP
        {
            get { return m_adep; }
            set { this.m_adep = value; }
        }
        public string ADEST
        {
            get { return m_adest; }
            set { this.m_adest = value; }
        }
        public string EOBT
        {
            get { return m_eobt; }
            set { this.m_eobt = value; }
        }
        //public bool AllowDrop
        //{
        //    get { return allowDrop; }
        //}

        #endregion

        public Strip()
        {
            InitializeComponent();

            #region ustawiam pictureboxy lineup, clear land/takeoff


            pbLineUp = new UpgradedPictureBox();
            pbLineUp.Image = EFS.Properties.Resources.LineUp;
            pbLineUp.Location = new Point(160, 30);
            pbLineUp.BackColor = Color.Transparent;
            pbLineUp.Visible = false;
            pbLineUp.Size = new Size(60, 30);
            pbLineUp.MouseClick += pbLineUp_MouseClick;
            pbLineUp.MouseDoubleClick += pbLineUp_MouseDoubleClick;
            this.Controls.Add(pbLineUp);

            pbBlank = new UpgradedPictureBox();
            pbBlank.Image = EFS.Properties.Resources.Blank;
            pbBlank.Location = new Point(160, 30);
            pbBlank.BackColor = Color.Transparent;
            pbBlank.Visible = true;
            pbBlank.Size = new Size(60, 30);
            pbBlank.MouseClick += pbBlank_click;

            pbLand = new UpgradedPictureBox();
            pbLand.Image = EFS.Properties.Resources.ClearLand;
            pbLand.Location = new Point(160, 30);
            pbLand.BackColor = Color.Transparent;
            pbLand.Visible = false;
            pbLand.Size = new Size(60, 30);
            pbLand.MouseDoubleClick += pbLand_MouseDoubleClick;
            this.Controls.Add(pbLand);

            pbTakeOff = new UpgradedPictureBox();
            pbTakeOff.Image = EFS.Properties.Resources.TakeOff;
            pbTakeOff.Location = new Point(160, 30);
            pbTakeOff.BackColor = Color.Transparent;
            pbTakeOff.Visible = false;
            pbTakeOff.Size = new Size(60, 30);
            pbTakeOff.MouseDoubleClick += pbTakeOff_MouseDoubleClick;
            this.Controls.Add(pbTakeOff);

            pbContApp = new UpgradedPictureBox();
            pbContApp.Image = EFS.Properties.Resources.ContinueApp;
            pbContApp.Location = new Point(160, 30);
            pbContApp.BackColor = Color.Transparent;
            pbContApp.Visible = false;
            pbContApp.Size = new Size(60, 30);
            pbContApp.MouseDoubleClick += pbContApp_MouseDoubleClick;
            pbContApp.MouseClick += pbContApp_MouseClick;

            this.Controls.Add(pbContApp);

            pbGoAround = new UpgradedPictureBox();
            pbGoAround.Image = EFS.Properties.Resources.GoAround;
            pbGoAround.Location = new Point(160, 30);
            pbGoAround.BackColor = Color.Transparent;
            pbGoAround.Visible = false;
            pbGoAround.Size = new Size(60, 30);
            pbGoAround.MouseDoubleClick += pbGoAround_MouseDoubleClick;
            this.Controls.Add(pbGoAround);


            #endregion
        }

        /// <summary>
        /// konstruktor tworzy pasek na podstawie poprawnego obiektu PlanLotu
        /// </summary>
        /// <param name="fpl"></param>
        public Strip(FlightPlan fpl)
        {
            
            doubleClickChecker.Interval = SystemInformation.DoubleClickTime;
            doubleClickChecker.Tick += doubleClickChecker_Tick;

            this.Capture = true;

            if (fpl.IsValid)
            {
                InitializeComponent();
                FPL = fpl;

                #region ustawiam pictureboxy lineup, clear land/takeoff


                pbLineUp = new UpgradedPictureBox();
                pbLineUp.Image = EFS.Properties.Resources.LineUp;
                pbLineUp.Location = new Point(160, 30);
                pbLineUp.BackColor = Color.Transparent;
                pbLineUp.Visible = false;
                pbLineUp.Size = new Size(60,30);
                pbLineUp.MouseClick += pbLineUp_MouseClick;
                pbLineUp.MouseDoubleClick += pbLineUp_MouseDoubleClick;
                this.Controls.Add(pbLineUp);

                pbBlank = new UpgradedPictureBox();
                pbBlank.Image = EFS.Properties.Resources.Blank;
                pbBlank.Location = new Point(160, 30);
                pbBlank.BackColor = Color.Transparent;
                pbBlank.Visible = true;
                pbBlank.Size = new Size(60,30);
                pbBlank.MouseClick += pbBlank_click;

                pbLand = new UpgradedPictureBox();
                pbLand.Image = EFS.Properties.Resources.ClearLand;
                pbLand.Location = new Point(160, 30);
                pbLand.BackColor = Color.Transparent;
                pbLand.Visible = false;
                pbLand.Size = new Size(60,30);
                pbLand.MouseDoubleClick += pbLand_MouseDoubleClick;
                this.Controls.Add(pbLand);

                pbTakeOff = new UpgradedPictureBox();
                pbTakeOff.Image = EFS.Properties.Resources.TakeOff;
                pbTakeOff.Location = new Point(160, 30);
                pbTakeOff.BackColor = Color.Transparent;
                pbTakeOff.Visible = false;
                pbTakeOff.Size = new Size(60, 30);
                pbTakeOff.MouseDoubleClick += pbTakeOff_MouseDoubleClick;
                this.Controls.Add(pbTakeOff);

                pbContApp = new UpgradedPictureBox();
                pbContApp.Image = EFS.Properties.Resources.ContinueApp;
                pbContApp.Location = new Point(160, 30);
                pbContApp.BackColor = Color.Transparent;
                pbContApp.Visible = false;
                pbContApp.Size = new Size(60,30);
                pbContApp.MouseDoubleClick += pbContApp_MouseDoubleClick;
                pbContApp.MouseClick += pbContApp_MouseClick;

                this.Controls.Add(pbContApp);

                pbGoAround = new UpgradedPictureBox();
                pbGoAround.Image = EFS.Properties.Resources.GoAround;
                pbGoAround.Location = new Point(160, 30);
                pbGoAround.BackColor = Color.Transparent;
                pbGoAround.Visible = false;
                pbGoAround.Size = new Size(60,30);
                pbGoAround.MouseDoubleClick += pbGoAround_MouseDoubleClick;
                this.Controls.Add(pbGoAround);


                #endregion

                m_callsign = fpl.Callsign;
                m_actype = fpl.Typ;
                m_adep = fpl.ADEP;
                m_adest = fpl.ADEST;
                m_transType = fpl.TransponderType;
                m_squawk = fpl.Squawk;
                m_route = fpl.Route;
                m_rfl = fpl.RFL;
                m_startPos = fpl.StartPos;
                CFL = fpl.ClearedLvl;
                m_arrStand = fpl.ArrStand;
                WakeTurb = fpl.WakeTurbCat;
                m_flightRules = fpl.FlightRules;
                m_status = fpl.Status;
                Runways = fpl.Runways;
                m_isVfr = fpl.IsVfr;

                m_presetObstSymb = Bay.Exercise.PresetObstSymb;
                m_presetTaxiTo = Bay.Exercise.PresetTaxiTo;

                if (fpl.FltType == FlightPlan.TypLotu.Arr)
                {
                    TypEFS = TypPaska.ARR;
                    m_depKolor = Color.LightYellow;
                    m_rfl = CFL;
                    m_eobt = fpl.StartTime;
                    m_rwy = fpl.ArrRwy;
                    m_presetStar = Bay.Exercise.PresetStar;
                    m_presetStand = Bay.Exercise.PresetStand;
                }
                else if (fpl.FltType == FlightPlan.TypLotu.Dep)
                {
                    TypEFS = TypPaska.DEP;
                    SIDs = fpl.SIDs;
                    m_depKolor = Color.LightBlue;
                    m_eobt = fpl.EOBT;
                    m_rwy = fpl.DepRwy;
                    m_sids = fpl.SIDs;
                    m_presetSid = Bay.Exercise.PresetSid;
                    m_presetStand = Bay.Exercise.PresetStand;
                        
                    if (fpl.CTOT != null)
                        m_ctot = fpl.CTOT;
                }
                else
                {
                    TypEFS = TypPaska.Overflight;
                    m_depKolor = Color.FromArgb(255, 125, 125); //jasnorozowoczerwony
                    m_rfl = CFL;
                }
            }
        }

        #region obsluga zdarzen pictureboxow
        void pbBlank_click(object sender, MouseEventArgs e)
        {
            if (this.TypEFS == TypPaska.ARR)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pbBlank.Visible = false;
                    pbContApp.Visible = true;
                }
            }
            else if (this.TypEFS == TypPaska.DEP)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pbBlank.Visible = false;
                    pbLineUp.Visible = true;
                }
            }
        }

        void pbGoAround_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pbGoAround.Visible = false;
                m_time = "";
                m_colorArrRectTime = Color.LightYellow;
                this.Invalidate();
            }
        }

        void pbContApp_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        void pbTakeOff_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pbTakeOff.Visible = false;
            }
        }

        void pbContApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pbContApp.Visible = false;
                pbLand.Visible = true;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pbContApp.Visible = false;
                pbGoAround.Visible = true;

                m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                
                m_colorArrRectTime = Color.Orange;
                
                this.Invalidate();
            }
        }

        void pbLand_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pbLand.Visible = false;
                pbGoAround.Visible = true;
                // todo niech w Time wskoczy czas g/a i kolor pola orange
                m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                m_colorArrRectTime = Color.Orange;
                this.Invalidate();
            }
        }

        void pbLineUp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pbLineUp.Visible = false;
                pbTakeOff.Visible = true;
            }

        }

        void pbLineUp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                pbLineUp.Visible = false;
        }
        #endregion 

        /// <summary>
        /// konstruktor tworzy pasek informacyjny, nie jest wymagany poprawny obiekt PlanLotu
        /// </summary>
        /// <param name="InfoText"></param>
        public Strip(String InfoText)
        {
            this.TypEFS = TypPaska.Info;
            m_depKolor = Color.DarkOrange;
            m_infoTextCenter = InfoText;
            InitializeComponent();
           
           m_callsign = InfoText;

            m_adep = "XXXX";
            m_adest = "XXXX";
            m_actype = "XXXX";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            switch (TypEFS)
            {
                case TypPaska.ARR:
                    DrawStrip(pe);
                    break;
                case TypPaska.DEP:
                    DrawStrip(pe);
                    break;
                case TypPaska.LocalEFS:
                    DrawLocalStrip(pe);
                    break;
                case TypPaska.LocalEFSArr:
                    DrawLocalStrip(pe);
                    break;
                case TypPaska.LocalEFSDep:
                    DrawLocalStrip(pe);
                    break;
                case TypPaska.Info:
                    DrawObstacleStrip(pe);
                    break;
            }
        }

        private void DrawObstacleStrip(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics gfx = pe.Graphics;
            Rectangle rc = ClientRectangle;


            this.Height = 50;
            //kolor ramek
            Pen ramki = new Pen(Color.Black);

            //gfx.FillRectangle(new SolidBrush(Color.White), new Rectangle(0,0, rc.Width-20, rc.Height));

            Rectangle leftTextAlightRect = new Rectangle(0, 0, 140, 49);
            Rectangle centerTextAlightRect = new Rectangle(140, 0, 150, 49);
            Rectangle rightTextAlightRect = new Rectangle(290, 0, 140, 49);
            Rectangle highlightRect = new Rectangle(430, 0, 20, 49);

            gfx.FillRectangles(new SolidBrush(Color.White), new Rectangle[] { leftTextAlightRect, rightTextAlightRect });
            gfx.FillRectangle(new SolidBrush(Color.LightGray), highlightRect);
            brushObstacle = new SolidBrush(m_colorObstacle);
            
            gfx.FillRectangle(brushObstacle, centerTextAlightRect);

            //obramowanie paska
            gfx.DrawRectangle(ramki, 0, 0, 449, 49);
            gfx.DrawRectangle(ramki, 0, 0, 140, 49);
            gfx.DrawRectangle(ramki, 140, 0, 290, 49);
            gfx.DrawRectangle(ramki, 290, 0, 429, 49);

            

            //linie pionowe
            //gfx.DrawLine(ramki, 90, 0, 90, 59);
            //gfx.DrawLine(ramki, 190, 0, 190, 59);

            Font czcionkaBDuza = new Font("Consolas", 16f, FontStyle.Bold);
            Font czcionkaDuza = new Font("Consolas", 10f);
            Font czcionkaMala = new Font("Consolas", 8f);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            

            gfx.DrawString(m_callsign, czcionkaBDuza, new SolidBrush(Color.Black), centerTextAlightRect, format);
            //gfx.DrawString(m_actype, czcionkaMala, new SolidBrush(Color.Black), new PointF(10f, 22f), format);

            //string transSquawk = m_transType.ToString() + "/" + m_squawk;

            //gfx.DrawString(transSquawk, czcionkaDuza, new SolidBrush(Color.Black), new PointF(10f, 40f), format);
            //gfx.DrawString(m_adep, czcionkaDuza, new SolidBrush(Color.Black), new PointF(100f, 5f), format);
            //gfx.DrawString(m_adest, czcionkaDuza, new SolidBrush(Color.Black), new PointF(100f, 40f), format);
            //gfx.DrawString(m_eobt, czcionkaMala, new SolidBrush(Color.Black), new PointF(100f, 22f), format);

            //gfx.DrawString(m_rfl, czcionkaDuza, new SolidBrush(Color.Black), new PointF(200f, 5f), format);
            //gfx.DrawString(m_route, czcionkaDuza, new SolidBrush(Color.Black), new PointF(200f, 40f), format);
        }

        private void DrawLocalStrip(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics gfx = pe.Graphics;
            //Rectangle rc = ClientRectangle;

            //kwadraty wypelniajace pasek:
           
                brushRectCallsigh = new SolidBrush(Color.LightPink);
                brushRectTime = new SolidBrush(Color.LightPink);
                brushRectEobtEta = new SolidBrush(Color.LightPink);
                brushKolor = new SolidBrush(Color.LightPink);
            

            //kolor ramek
            Pen ramki = new Pen(Color.Black);
            Pen hightlight = new Pen(Color.Red, 2f);

            //maluje tla
            //najpierw pola o niezmiennym kolorze
            Rectangle[] StaticColorFrames = new Rectangle[] { rectAtis, rectRwy, rectSidStar, rectAcInfo, rectClearance, rectTaxiTo, rectStand };
            gfx.FillRectangles(brushKolor, StaticColorFrames);

            //teraz pola zmiennokolorowe
            gfx.FillRectangle(brushRectCallsigh, rectCallsign);
          
                gfx.FillRectangle(new SolidBrush(Color.LightPink), rectTime);
                gfx.FillRectangle(new SolidBrush(Color.LightPink), rectEobtEta);
            

            //maluj pole highlight
            gfx.DrawRectangle(ramki, rectHighlight);
            gfx.FillRectangle(new SolidBrush(Color.LightGray), rectHighlight);

            //obramowanie paska
            gfx.DrawRectangle(ramki, 0f, 0f, 449f, 59f);

            //do centrowania callsignu
            //Rectangle rectCs = new Rectangle(110, 0, 370, 65);

            StringFormat textCenterAlignment = new StringFormat();
            textCenterAlignment.Alignment = StringAlignment.Center;
            textCenterAlignment.LineAlignment = StringAlignment.Center;

            StringFormat callsignAlignment = new StringFormat();
            callsignAlignment.Alignment = StringAlignment.Center;
            callsignAlignment.LineAlignment = StringAlignment.Center;

            //linie pionowe
            gfx.DrawLine(ramki, 20, 0, 20, 29);
            gfx.DrawLine(ramki, 90, 0, 90, 59);
            gfx.DrawLine(ramki, 160, 0, 160, 59);
            gfx.DrawLine(ramki, 220, 0, 220, 59);
            gfx.DrawLine(ramki, 370, 0, 370, 59);
            gfx.DrawLine(ramki, 429, 0, 429, 59);

            //linia pozioma
            gfx.DrawLine(ramki, 0, 30, 220, 30);
            gfx.DrawLine(ramki, 370, 30, 429, 30);

            Font czcionkaBDuza = new Font("Consolas", 23f, FontStyle.Bold);
            Font czcionkaDuza = new Font("Consolas", 14f);
            Font czcionkaDuza2 = new Font("Consolas", 14f, FontStyle.Bold);
            Font czcionkaMala = new Font("Consolas", 11f);

            StringFormat format = new StringFormat();

            gfx.DrawString(m_callsign, czcionkaBDuza, new SolidBrush(Color.Black), rectCallsignAlignment, callsignAlignment);
            gfx.DrawString(m_actype + "/" + WakeTurb, czcionkaMala, new SolidBrush(Color.Black), rectFreeTextIndicator, textCenterAlignment);
            gfx.DrawString(m_atis, czcionkaDuza, new SolidBrush(Color.Black), rectAtis, textCenterAlignment);
            gfx.DrawString(m_time, czcionkaDuza, new SolidBrush(Color.Black), rectTime, textCenterAlignment);
            gfx.DrawString(m_rwy, czcionkaDuza, new SolidBrush(Color.Black), rectRwy, textCenterAlignment);

            
                gfx.DrawString(m_arrStand, czcionkaMala, new SolidBrush(Color.Black), rectStand, textCenterAlignment);
                gfx.DrawString(m_landState, czcionkaDuza2, new SolidBrush(Color.Green), rectClearance, textCenterAlignment);
                gfx.DrawString(m_route, czcionkaMala, new SolidBrush(Color.Black), rectSidStar, textCenterAlignment);
            

            gfx.DrawString(m_squawk, czcionkaMala, new SolidBrush(Color.Black), new PointF(330f, 42f), format);
            gfx.DrawString(m_adep, czcionkaMala, new SolidBrush(Color.Black), new PointF(225f, 1f), format);
            gfx.DrawString(m_adest, czcionkaMala, new SolidBrush(Color.Black), new PointF(330f, 1f), format);
            gfx.DrawString(m_taxiTo, czcionkaMala, new SolidBrush(Color.Black), rectTaxiTo, textCenterAlignment);

            #region Draw Status
            if (m_status != "")
            {
                SizeF statusSize = gfx.MeasureString(m_status, czcionkaMala);
                Rectangle statusBackground = new Rectangle(227, 44, (int)statusSize.Width - 4, (int)statusSize.Height - 7);
                gfx.FillRectangle(new SolidBrush(Color.Orange), statusBackground);
                gfx.DrawString(m_status, czcionkaMala, new SolidBrush(Color.Black), new PointF(225f, 42f), format);
            }
            #endregion

            gfx.DrawString(m_eobt, czcionkaMala, new SolidBrush(Color.Black), rectEobtEta, textCenterAlignment);

            gfx.DrawString(m_rfl, czcionkaMala, new SolidBrush(Color.Black), new PointF(275f, 1f), format);


            if (m_extendedShown)
                UpdateExtendedStripDep();

            if (m_freeTextFilled)
                gfx.DrawRectangle(new Pen(Color.Red, 2f), rectFreeTextIndicator);
        }
       
        private void DrawStrip(PaintEventArgs pe)
        { 
            base.OnPaint(pe);
            Graphics gfx = pe.Graphics;
            //Rectangle rc = ClientRectangle;

            //kwadraty wypelniajace pasek:
            if (TypEFS == TypPaska.DEP)
            {
                 brushRectCallsigh = new SolidBrush(m_colorDepRectCallsign);
                 brushRectTime = new SolidBrush(m_colorDepRectTime);
                 brushRectEobtEta = new SolidBrush(m_colorDepRectEobtEta);
                 brushKolor = new SolidBrush(m_depKolor);
            }
            else if (TypEFS == TypPaska.ARR)
            {
                 brushRectCallsigh = new SolidBrush(m_colorArrRectCallsign);
                 brushRectTime = new SolidBrush(m_colorArrRectTime);
                 brushRectEobtEta = new SolidBrush(m_colorArrRectEobtEta);
                 brushKolor = new SolidBrush(m_arrKolor);
            }

            //kolor ramek
            Pen ramki = new Pen(Color.Black);
            Pen hightlight = new Pen(Color.Red, 2f);

            //maluje tla
            //najpierw pola o niezmiennym kolorze
            Rectangle[] StaticColorFrames = new Rectangle[] {rectAtis, rectRwy, rectSidStar, rectAcInfo, rectClearance, rectTaxiTo, rectStand };
            gfx.FillRectangles(brushKolor, StaticColorFrames);

            //teraz pola zmiennokolorowe
            gfx.FillRectangle(brushRectCallsigh, rectCallsign);
            if (TypEFS == TypPaska.DEP)
            {
                gfx.FillRectangle(new SolidBrush(m_colorDepRectTime), rectTime);

                #region handle backcolor if slot assigned
                if (m_ctot != "" && m_ctot.Length == 4)
                {
                    TimeSpan timeDiff = CalculateTimespan(Bay.czasCwiczenia, m_ctot);
                    m_eobt = m_ctot;

                    if (timeDiff.Minutes <= -5 && !SlotPassedToAirplane)
                    {
                        SlotAction = true;
                        m_colorDepRectEobtEta = Color.Yellow;
                    }


                    if (timeDiff.Minutes <= 10)
                    {
                        SlotAction = true;
                        m_colorDepRectEobtEta = Color.Orange;
                    }
                    else if (timeDiff.Minutes > 10)
                    {
                        SlotAction = true;
                        m_colorDepRectEobtEta = Color.Red;
                    }
                    else
                        SlotAction = false;
                }


                gfx.FillRectangle(new SolidBrush(m_colorDepRectEobtEta), rectEobtEta);

                #endregion
            }
            else if (TypEFS == TypPaska.ARR)
            {
                gfx.FillRectangle(new SolidBrush(m_colorArrRectTime), rectTime);
                gfx.FillRectangle(brushRectEobtEta, rectEobtEta);
            }

            //maluj pole highlight
            gfx.DrawRectangle(ramki, rectHighlight);
            gfx.FillRectangle(new SolidBrush(Color.LightGray), rectHighlight);

            //obramowanie paska
            gfx.DrawRectangle(ramki, 0f, 0f, 449f, 59f);
            
            //do centrowania callsignu
            //Rectangle rectCs = new Rectangle(110, 0, 370, 65);
            
            StringFormat textCenterAlignment = new StringFormat();
            textCenterAlignment.Alignment = StringAlignment.Center;
            textCenterAlignment.LineAlignment = StringAlignment.Center;

            StringFormat callsignAlignment = new StringFormat();
            callsignAlignment.Alignment = StringAlignment.Center;
            callsignAlignment.LineAlignment = StringAlignment.Center;

            //linie pionowe
            gfx.DrawLine(ramki, 20, 0, 20, 29);
            gfx.DrawLine(ramki, 90, 0, 90, 59);
            gfx.DrawLine(ramki, 160, 0, 160, 59);
            gfx.DrawLine(ramki, 220, 0, 220, 59);
            gfx.DrawLine(ramki, 370, 0, 370, 59);
            gfx.DrawLine(ramki, 429, 0, 429, 59);

            //linia pozioma
            gfx.DrawLine(ramki, 0, 30, 220, 30);
            gfx.DrawLine(ramki, 370, 30, 429, 30);

            Font czcionkaBDuza = new Font("Consolas", 23f, FontStyle.Bold);
            Font czcionkaDuza = new Font("Consolas", 14f);
            Font czcionkaDuza2 = new Font("Consolas", 14f, FontStyle.Bold);
            Font czcionkaMala = new Font("Consolas", 11f);

            StringFormat format = new StringFormat();

            gfx.DrawString(m_callsign, czcionkaBDuza, new SolidBrush(Color.Black), rectCallsignAlignment, callsignAlignment);
            gfx.DrawString(m_actype + "/" + WakeTurb, czcionkaMala, new SolidBrush(Color.Black), rectFreeTextIndicator, textCenterAlignment);
            gfx.DrawString(m_atis, czcionkaDuza, new SolidBrush(Color.Black), rectAtis, textCenterAlignment);
            gfx.DrawString(m_time, czcionkaDuza, new SolidBrush(Color.Black), rectTime, textCenterAlignment);
            gfx.DrawString(m_rwy, czcionkaDuza, new SolidBrush(Color.Black), rectRwy, textCenterAlignment);

            if (TypEFS == TypPaska.DEP)
            {
                gfx.DrawString(m_startPos, czcionkaMala, new SolidBrush(Color.Black), rectStand, textCenterAlignment);
                gfx.DrawString("", czcionkaDuza2, new SolidBrush(Color.Blue), rectClearance, textCenterAlignment);
                gfx.DrawString(this.GetSid(m_rwy), czcionkaMala, new SolidBrush(Color.Black), rectSidStar, textCenterAlignment);
            }
            else if (TypEFS == TypPaska.ARR)
            {
                gfx.DrawString(m_arrStand, czcionkaMala, new SolidBrush(Color.Black), rectStand, textCenterAlignment);
                gfx.DrawString(m_landState, czcionkaDuza2, new SolidBrush(Color.Green), rectClearance, textCenterAlignment);
                gfx.DrawString(m_route, czcionkaMala, new SolidBrush(Color.Black), rectSidStar, textCenterAlignment);
            }

            gfx.DrawString(m_squawk, czcionkaMala, new SolidBrush(Color.Black), new PointF(330f, 42f), format);
            gfx.DrawString(m_adep, czcionkaMala, new SolidBrush(Color.Black), new PointF(225f, 1f), format);
            gfx.DrawString(m_adest, czcionkaMala, new SolidBrush(Color.Black), new PointF(330f, 1f), format);
            gfx.DrawString(m_taxiTo, czcionkaMala, new SolidBrush(Color.Black), rectTaxiTo, textCenterAlignment);

            #region Draw Status
            if (m_status != "")
            {
                SizeF statusSize = gfx.MeasureString(m_status, czcionkaMala);
                Rectangle statusBackground = new Rectangle(227, 44, (int)statusSize.Width-4, (int)statusSize.Height-7);
                gfx.FillRectangle(new SolidBrush(Color.Orange), statusBackground);
                gfx.DrawString(m_status, czcionkaMala, new SolidBrush(Color.Black), new PointF(225f, 42f), format);
            }
            #endregion

            gfx.DrawString(m_eobt, czcionkaMala, new SolidBrush(Color.Black), rectEobtEta, textCenterAlignment);

            gfx.DrawString(m_rfl, czcionkaMala, new SolidBrush(Color.Black), new PointF(275f, 1f), format);
            

            if (m_extendedShown)
                UpdateExtendedStripDep();
            
            if (m_freeTextFilled)
                gfx.DrawRectangle(new Pen(Color.Red, 2f), rectFreeTextIndicator);

            if (m_isVfr)
                gfx.DrawRectangle(new Pen(Color.Red, 2f), rectVfrIndicator);
        }

        private string GetSid(string p)
        {
            // najpierw sprawdzam czy jestem w stanie wstawic od razu sid, jesli tak to go wstawiam, jesli nie 
            // to wyswietla normalnie zawartosc pola m_route
            List<SID> tempSidList = new List<SID>();
            string matchingSid = "";
            

            //wybieram tylko sidy dla danego pasa
            

            if (m_sids.Count != 0)
            {
                foreach (SID s in m_sids)
                    if (s.RWY == p)
                        tempSidList.Add(s);

                //teraz z sidow dla wlasciwego pasa wybieram ten ktory zgadza sie poczatkiem nazwy z polem route
                foreach (SID s in tempSidList)
                    if (s.ProcName.Contains(m_route))
                        matchingSid = s.ProcName;

                if (matchingSid != "")
                    return matchingSid;
            }
            return m_route;
        }

        private TimeSpan CalculateTimespan(DateTime exerciseTime, string m_ctot)
        {
            DateTime ctot = new DateTime(exerciseTime.Year, exerciseTime.Month, exerciseTime.Day, int.Parse(m_ctot.Substring(0, 2)), int.Parse(m_ctot.Substring(2, 2)), 0);

            return (exerciseTime - ctot);
        }

        public bool IsSlotActionNeeded()
        {
            TimeSpan timeDiff = CalculateTimespan(Bay.czasCwiczenia, m_ctot);

            if (timeDiff.Minutes <= -5)
            {
                return true;
            }
            else if (timeDiff.Minutes <= 10)
            {
                return true;
            }
            else if (timeDiff.Minutes > 10)
            {
                return true;
            }
            else
                return false;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }

        private void frm_FormClosingSid(object sender, FormClosingEventArgs e)
        {
            
            testowa x = (testowa)sender;


            if (x.ReturnValue == "-free-")
            {
                FreeTextWindow ftw = new FreeTextWindow();
                ftw.ShowDialog();

                if (ftw.FreeText != null)
                    m_route = ftw.FreeText;
            }
            else if (x.ReturnValue != null)
            {
                m_route = x.ReturnValue;
            }
            this.Invalidate();
        }

        private void frm_FormClosingStar(object sender, FormClosingEventArgs e)
        {
            testowa x = (testowa)sender;

            if (x.ReturnValue == "-free-")
            {
                FreeTextWindow ftw = new FreeTextWindow();
                ftw.ShowDialog();

                if (ftw.FreeText != null)
                    m_route = ftw.FreeText;
            }
            else if (x.ReturnValue != null)
            {
                m_route = x.ReturnValue;
            }
            this.Invalidate();
        }

        void frm_FormClosingRwy(object sender, FormClosingEventArgs e)
        {
            testowa x = (testowa)sender;
            if (x.ReturnValue != null)
                m_rwy = x.ReturnValue;
            this.Invalidate();
        }

        void frm_FormClosingTaxiTo(object sender, FormClosingEventArgs e)
        {   
            testowa x = (testowa)sender;
            if (x.ReturnValue == "-free-")
            {
                FreeTextWindow ftw = new FreeTextWindow();
                ftw.ShowDialog();

                if (ftw.FreeText != null)
                    m_taxiTo = ftw.FreeText;
            }
            else
                if (x.ReturnValue != null && x.ReturnValue != "")
                    m_taxiTo = x.ReturnValue;

            this.Invalidate();
        }

        private void frm_FormClosingStand(object sender, FormClosingEventArgs e)
        {
            testowa x = (testowa)sender;
            if (x.ReturnValue == "-free-")
            {
                FreeTextWindow ftw = new FreeTextWindow();
                ftw.ShowDialog();

                if (ftw.DialogResult == DialogResult.OK)
                    if (ftw.FreeText != null)
                    {
                        m_startPos = ftw.FreeText;
                        m_arrStand = ftw.FreeText;
                    }
            }
            else
                if (x.ReturnValue != null && x.ReturnValue != "")
                {
                    m_startPos = x.ReturnValue;
                    m_arrStand = x.ReturnValue;
                }
            this.Invalidate();
        }

        private void frm_FormClosingInfoStrip(object sender, FormClosingEventArgs e)
        { 
                testowa x = (testowa)sender;
                if (x.ReturnValue == "-free-")
                {
                    FreeTextWindow ftw = new FreeTextWindow();
                    ftw.ShowDialog();

                    if (ftw.DialogResult == DialogResult.OK)
                        if (ftw.FreeText != null)
                            m_callsign = ftw.FreeText;
                    
                }
                else
                    if (x.ReturnValue != null && x.ReturnValue != "")
                        m_callsign = x.ReturnValue;
                
                this.Invalidate();
        }

        private void frm_FormClosingLocalEFS(object sender, FormClosingEventArgs e)
        {
            testowa x = (testowa)sender;
            if (x.ReturnValue == "-free-")
            {
                InputLocalEfsData iled = new InputLocalEfsData();
                iled.ShowDialog();

                if (iled.DialogResult == DialogResult.OK)
                {
                    this.Callsign = iled.Acid;
                    this.ACType = iled.Typ;
                    this.WakeTurb = iled.W;
                }

            }

            this.Invalidate();
        }
 

        private void HideExtendedStripDep()
        {       
            this.Size = new Size(450, 60);
            this.m_extendedShown = false;
            this.m_freeText = txtFreeText.Text;

            if (this.m_freeText != "")
                this.m_freeTextFilled = true;
            else
                this.m_freeTextFilled = false;

            lblTimes.Dispose();
            txtFreeText.Dispose();
        }

        private void DrawExtendedStripDep()
        {
            
            this.Size = new Size(450, 110);
            Graphics gfx = this.CreateGraphics();

            Rectangle fill = new Rectangle(0, 60, 450, 110);

            if (TypEFS == TypPaska.ARR)
                gfx.FillRectangle(new SolidBrush(Color.LightYellow), fill);
            else if (TypEFS == TypPaska.DEP)
                gfx.FillRectangle(new SolidBrush(Color.LightBlue), fill);
            else if (TypEFS == TypPaska.LocalEFSDep || this.TypEFS == TypPaska.LocalEFSArr)
                gfx.FillRectangle(new SolidBrush(Color.LightPink), fill);

            Pen dashedLine = new Pen(Color.Black);
            float[] dashValues = { 5, 5 };
            dashedLine.DashPattern = dashValues;
            gfx.DrawLine(dashedLine, 0f, 60f, 0f, 110f);
            gfx.DrawLine(dashedLine, 0f, 109f, 449f, 109f);
            gfx.DrawLine(dashedLine, 449f, 60f, 449f, 110f);

            //Pole Freetext
            txtFreeText = new TextBox();
            txtFreeText.Parent = (Control)this;
            txtFreeText.Location = new Point(10, 85);
            txtFreeText.Size = new Size(400, txtFreeText.Size.Height);
            txtFreeText.Text = m_freeText;
            

            //belka z czasami
            string times = string.Format("{0}-{1}-{2}-{3}", m_clearanceTime, m_startupTime, m_pushbackTime, m_airborneTime);
            lblTimes = new Label();
            lblTimes.AutoSize = true;
            lblTimes.Font = new Font("Consolas", 10f);
            if (TypEFS == TypPaska.ARR)
                lblTimes.BackColor = Color.LightYellow;
            else if (TypEFS == TypPaska.DEP)
                lblTimes.BackColor = Color.LightBlue;
            lblTimes.Parent = (Control)this;
            lblTimes.Location = new Point(10, 64);
            lblTimes.Text = times;

            m_extendedShown = true;

            

        }

        private void UpdateExtendedStripDep()
        {
            Graphics gfx = this.CreateGraphics();

            Rectangle fill = new Rectangle(0, 60, 450, 110);

            if (TypEFS == TypPaska.ARR)
                gfx.FillRectangle(new SolidBrush(Color.LightYellow), fill);
            else if (TypEFS == TypPaska.DEP)
                gfx.FillRectangle(new SolidBrush(Color.LightBlue), fill);

            Pen dashedLine = new Pen(Color.Black);
            float[] dashValues = { 5, 5 };
            dashedLine.DashPattern = dashValues;
            gfx.DrawLine(dashedLine, 0f, 60f, 0f, 110f);
            gfx.DrawLine(dashedLine, 0f, 109f, 449f, 109f);
            gfx.DrawLine(dashedLine, 449f, 60f, 449f, 110f);

            
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            //this.Capture = true;

            if (this.TypEFS == TypPaska.Info)
            {
                if (e.X > 140 && e.X < 290 & e.Y > 0 && e.Y < 50)
                {
                    if (e.Button == MouseButtons.Left)
                        DoDragDrop(this, DragDropEffects.All);
                }

            }
            else if (TypEFS == TypPaska.ARR || TypEFS == TypPaska.DEP || TypEFS == TypPaska.LocalEFSArr || TypEFS == TypPaska.LocalEFSDep)
            {
                if (e.X > 220 && e.X < 370 & e.Y > 0 && e.Y < 60)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        var drag = DoDragDrop(this, DragDropEffects.All);
                        if (drag == DragDropEffects.None || drag == DragDropEffects.Move)
                        {

                            //jak wyciagne i upuszcze kontrolke poza dozwolone pola to kolor CS zostaje brazowy,
                            //dzieki temu kawalkowi kodu tak dzie nie dzieje. To samo jest w kilku miejscach jeszcze
                            //ale nie wiem czy mozna stamtad usunac
                            #region zabezpieczenie przed pozostawaniem pola callsign w brazowym kolorze
                            if (m_colorDepRectCallsign == Color.Chocolate || m_colorArrRectCallsign == Color.Chocolate)
                            {
                                m_colorArrRectCallsign = m_tempColor;
                                m_colorDepRectCallsign = m_tempColor;

                                this.Invalidate();
                            }

                            #endregion
                        }


                        return;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {

                    }
                }
            }


            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.TypEFS == TypPaska.ARR || this.TypEFS == TypPaska.DEP || this.TypEFS == TypPaska.LocalEFSDep || this.TypEFS == TypPaska.LocalEFSArr)
            {
                #region click w runway
                if (e.X > 20 && e.X < 90 & e.Y > 0 && e.Y < 30)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        testowa frm = new testowa(Runways);
                        frm.FormClosing += frm_FormClosingRwy;
                        frm.Show();
                    }
                }
                #endregion

                #region click w taxiTo
                if (e.X > 370 && e.X < 430 & e.Y > 0 && e.Y < 30)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        testowa frm = new testowa(true, m_presetTaxiTo);
                        frm.FormClosing += frm_FormClosingTaxiTo;
                        frm.Show();
                    }
                }
                #endregion

                #region click w sidStar
                if (e.X > 0 && e.X < 90 & e.Y > 30 && e.Y < 60)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (this.TypEFS == TypPaska.DEP)
                        {
                            //najpierw wybieram sidy dla aktualnego pasa:
                            List<string> tempSidList = new List<string>();

                            if (m_presetSid != null)
                                tempSidList.AddRange(m_presetSid);

                            try
                            {
                                foreach (SID s in SIDs)
                                {
                                    if (s.RWY == m_rwy)
                                        tempSidList.Add(s.ProcName);
                                }
                            }
                            catch { }

                            testowa frm = new testowa(true, tempSidList);
                            frm.FormClosing += frm_FormClosingSid;
                            frm.Show();
                        }
                        else if (this.TypEFS == TypPaska.ARR)
                        {
                            testowa frm = new testowa(true, m_presetStar);
                            frm.FormClosing += frm_FormClosingStar;
                            frm.Show();
                        }
                        else if (this.TypEFS == TypPaska.LocalEFSArr || this.TypEFS == TypPaska.LocalEFSDep)
                        {
                            List<string> efsOps = new List<string>();

                            efsOps.Add("TG");
                            efsOps.Add("LP");
                            efsOps.Add("LC");
                            efsOps.Add("RC");
                            efsOps.Add("OV");
                            


                            testowa frm = new testowa(true, efsOps);
                            frm.FormClosing += frm_FormClosingStar;
                            frm.Show();
                        }
                    }
                }
                #endregion

                #region click w callsign
                if (e.X > 220 && e.X < 370 & e.Y > 0 && e.Y < 59)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {

                        // odkolorowanie na poprzedni kolor (m_tempColor) nastepuje w bay.cs w metodzie flowPanel_DragDrop
                        if (this.TypEFS == TypPaska.DEP)
                            this.m_tempColor = this.m_colorDepRectCallsign;
                        else if (this.TypEFS == TypPaska.ARR)
                            this.m_tempColor = this.m_colorArrRectCallsign;


                        this.m_colorArrRectCallsign = Color.Chocolate;
                        this.m_colorDepRectCallsign = Color.Chocolate;
                        this.Invalidate();
                        //m_rwy = frm.ReturnValue;
                    }


                    //(e.X > 140 && e.X < 290 & e.Y > 0 && e.Y < 49
                    if (this.TypEFS == TypPaska.Info)
                    {

                        //tu obsluguje dodawanie local efs z przycisku
                        //List<string> obstacleNames = new List<string>();
                        //obstacleNames.Add("DYZURNY");
                        //obstacleNames.Add("SOKOLNIK");
                        //obstacleNames.Add("TECHNIK");

                        //testowa frm = new testowa(true, obstacleNames);
                        //frm.FormClosing += frm_FormClosingInfoStrip;
                        //frm.Show();

                    }

                }

                this.Invalidate();
                #endregion

                #region Click w stand
                if (e.X > 370 && e.X < 430 & e.Y > 30 && e.Y < 59)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        testowa frm = new testowa(true, m_presetStand);
                        frm.FormClosing += frm_FormClosingStand;
                        frm.Show();
                    }
                }

                #endregion
            }
            else if (this.TypEFS == TypPaska.Info)
            {
                #region click w callsign
                if (e.X > 140 && e.X < 290 & e.Y > 0 && e.Y < 49)
                {
                    //pozwalam na wyskakujace menu tylko podczas tworzenia obstacle symbol
                    //wiem ze jestem w fazie tworzenia jesli parent obiektu to forma AddObstacleStrip
                    //a nie flowlayout panel. po stworzeniu paska i dodaniu na panel to pole sluzy juz tylko do przeciagania paska
                    if (this.Parent.GetType() == typeof(AddObstacleStrip))
                    {
                        //tu obsluguje dodawanie local efs z przycisku

                        testowa frm = new testowa(true, m_presetObstSymb, (AddObstacleStrip)this.Parent);
                        
                        frm.Show();
                        frm.FormClosing += frm_FormClosingInfoStrip;
                    }
                }
                //AddObstacleStrip xf = (AddObstacleStrip)this.Parent;
                //xf.BringToFront();
                this.Invalidate();
                #endregion
            }
            else if (this.TypEFS == TypPaska.LocalEFS)
            {
                #region click w callsign
                if (e.X > 220 && e.X < 370 & e.Y > 0 && e.Y < 59)
                {
                    //pozwalam na wyskakujace menu tylko podczas tworzenia local EFS
                    //wiem ze jestem w fazie tworzenia jesli parent obiektu to forma AddLocalEFS
                    //a nie flowlayout panel. po stworzeniu paska i dodaniu na panel to pole sluzy juz tylko do przeciagania paska
                    if (this.Parent.GetType() == typeof(AddLocalEFS))
                    {
                        //tu obsluguje dodawanie local efs z przycisku

                        //trzeba bedzie sie zastanowic
                        testowa frm = new testowa(true, null, (AddLocalEFS)this.Parent);

                        frm.Show();
                        frm.FormClosing += frm_FormClosingLocalEFS;
                    }
                }
                
                #endregion

                #region click w runway
                if (e.X > 20 && e.X < 90 & e.Y > 0 && e.Y < 30)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        testowa frm = new testowa(Runways);
                        frm.FormClosing += frm_FormClosingRwy;
                        frm.Show();
                    }
                }
                #endregion


                this.Invalidate();
            }
            
            base.OnMouseDown(e);
        }
        
        
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Graphics gfx = this.CreateGraphics();

            //sprawdzam gdzie uzytkownik kliknal, w zaleznosci od pozycji wykonuje jakas akcje

            #region klik w Clearance
            if (e.X > 160 && e.X < 220 & e.Y > 30 && e.Y < 60)
            {
                if (this.TypEFS == TypPaska.Info)
                    return;

                if (this.TypEFS == TypPaska.ARR || this.TypEFS == TypPaska.LocalEFSArr)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        pbContApp.Visible = true;
                }
                else if (this.TypEFS == TypPaska.DEP || this.TypEFS == TypPaska.LocalEFSDep)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        pbLineUp.Visible = true;
                }
                //MessageBox.Show("ZarazWykonam!");
                

                //m_eobt = czas.Remove(2, 1);
            }
            #endregion

            #region klik w ATIS
            if (e.X > 0 && e.X < 20 & e.Y > 0 && e.Y < 30)
            {
                if (this.TypEFS == TypPaska.Info)
                    return;

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    AtisWindow frmAtis = new AtisWindow(this.m_atis);
                    //frmAtis.Location = new Point(e.X, e.Y);

                    int X = Cursor.Position.X;
                    int Y = Cursor.Position.Y;

                    // MessageBox.Show(String.Format("{0} x {1}", X, Y));



                    //frmAtis.DesktopLocation = new Point(0,0);
                    frmAtis.Location = new Point(X, Y);
                    frmAtis.ShowDialog();
                    this.m_atis = frmAtis.Designator;




                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (m_atis == "")
                        m_atis = Bay.ATIS;
                    else
                        m_atis = Bay.ATIS;
                }

                //this.Invalidate();
            }

            #endregion

            #region klik w Callsign
            if (e.X > 220 && e.X < 370 & e.Y > 0 && e.Y < 60)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (this.TypEFS == TypPaska.Info)
                        return;


                    if (!m_extendedShown)
                        DrawExtendedStripDep();
                    else
                        HideExtendedStripDep();

                }
            }
            #endregion

            #region klik w Time
            

            if (e.X > 90 && e.X < 160 && e.Y > 30 && e.Y < 60)
            {
                //moj wrapper na przekazanie funkcji do doubleclickchecker.tick
                object[] wrapper = new object[] { this, e };

                doubleClickChecker.Tag = wrapper;
                doubleClickChecker.Start();

            }
            #endregion

            #region klik w Highlight
            if (e.X > 430 && e.X < 450 && e.Y > 0 && e.Y < 60)
            {
                if (this.TypEFS == TypPaska.DEP)
                {
                    #region zmiany koloru lewy prawy klik
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (m_colorDepRectCallsign == Color.LightBlue)
                            m_colorDepRectCallsign = Color.DeepSkyBlue;
                        else if (m_colorDepRectCallsign == Color.DeepSkyBlue)
                            m_colorDepRectCallsign = Color.LightBlue;
                        else if (m_colorDepRectCallsign == Color.Yellow)
                            m_colorDepRectCallsign = Color.DeepSkyBlue;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (m_colorDepRectCallsign == Color.LightBlue)
                            m_colorDepRectCallsign = Color.Yellow;
                        else if (m_colorDepRectCallsign == Color.Yellow)
                            m_colorDepRectCallsign = Color.LightBlue;
                        else if (m_colorDepRectCallsign == Color.DeepSkyBlue)
                            m_colorDepRectCallsign = Color.Yellow;
                    }
                    #endregion
                }
                else if (this.TypEFS == TypPaska.ARR)
                {
                    #region zmiany koloru lewy prawy klik
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (m_colorArrRectCallsign == Color.LightYellow)
                            m_colorArrRectCallsign = Color.DeepSkyBlue;
                        else if (m_colorArrRectCallsign == Color.DeepSkyBlue)
                            m_colorArrRectCallsign = Color.LightYellow;
                        else if (m_colorArrRectCallsign == Color.Yellow)
                            m_colorArrRectCallsign = Color.DeepSkyBlue;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (m_colorArrRectCallsign == Color.LightYellow)
                            m_colorArrRectCallsign = Color.Yellow;
                        else if (m_colorArrRectCallsign == Color.Yellow)
                            m_colorArrRectCallsign = Color.LightYellow;
                        else if (m_colorArrRectCallsign == Color.DeepSkyBlue)
                            m_colorArrRectCallsign = Color.Yellow;
                    }
                    #endregion
                }
                else if (this.TypEFS == TypPaska.Info)
                {
                    #region zmiany koloru lewy prawy klik
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (m_colorObstacle == Color.White)
                            m_colorObstacle = Color.DeepSkyBlue;
                        else if (m_colorObstacle == Color.Yellow)
                            m_colorObstacle = Color.DeepSkyBlue;
                        else if (m_colorObstacle == Color.DeepSkyBlue)
                            m_colorObstacle = Color.White;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (m_colorObstacle == Color.White)
                            m_colorObstacle = Color.Yellow;
                        else if (m_colorObstacle == Color.DeepSkyBlue)
                            m_colorObstacle = Color.Yellow;
                        else if (m_colorObstacle == Color.Yellow)
                            m_colorObstacle = Color.White;
                    }
                    #endregion
                }
            }
            #endregion

            #region klik w sid
            // 0 30, 90, 59
            if (e.X > 0 && e.X < 90 && e.Y > 30 && e.Y < 59)
            {
                if (this.TypEFS == TypPaska.Info)
                    return;

                if (this.TypEFS == TypPaska.DEP)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        SidWindow frmSid = new SidWindow(this.SIDs, m_rwy);
                        //frmAtis.Location = new Point(e.X, e.Y);

                        //int X = Cursor.Position.X;
                        //int Y = Cursor.Position.Y;

                        //// MessageBox.Show(String.Format("{0} x {1}", X, Y));



                        ////frmAtis.DesktopLocation = new Point(0,0);
                        //frmSid.Location = new Point(X, Y);
                        frmSid.ShowDialog();

                        if (frmSid.UserSelectedSid)
                            m_route = frmSid.SelectedSid;
                        else if (frmSid.UserSelectedHdgAlt)
                            m_route = frmSid.SelectedSid;
                    }
                }
                else if (this.TypEFS == TypPaska.ARR)
                {

                }
            }

            #endregion

            #region klik w EOBT
            if (e.X > 160 && e.X < 220 && e.Y > 0 && e.Y < 30)
            {
                if (this.TypEFS == TypPaska.DEP)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (this.m_colorDepRectEobtEta == Color.Yellow)
                        {
                            this.SlotPassedToAirplane = true;
                            this.m_colorDepRectEobtEta = Color.Gray;
                        }
                    }
                }
            }


            #endregion

            #region klik w stand
            if (e.X > 370 && e.X < 430 && e.Y > 30 && e.Y < 59)
            {
                
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        FreeTextWindow ftw = new FreeTextWindow();
                        if (ftw.ShowDialog() == DialogResult.OK)
                            if (this.TypEFS == TypPaska.ARR)
                                this.m_arrStand = ftw.FreeText;
                            else if (this.TypEFS == TypPaska.DEP)
                                this.m_startPos = ftw.FreeText;
                    }
             }
            #endregion

            #region zabezpieczenie przed pozostawaniem pola callsign w brazowym kolorze
            if (m_colorDepRectCallsign == Color.Chocolate || m_colorArrRectCallsign == Color.Chocolate)
            {
                m_colorArrRectCallsign = m_tempColor;
                m_colorDepRectCallsign = m_tempColor;
            }
            #endregion

            this.Invalidate();
            base.OnMouseClick(e);
        }


        void doubleClickChecker_Tick(object sender, EventArgs evAr)
        {
            doubleClickChecker.Stop();
            object[] wr = (object[])doubleClickChecker.Tag;
            MouseEventArgs e = (MouseEventArgs)wr[1];
            Strip efs = (Strip)wr[0];


            if (efs.TypEFS == TypPaska.Info)
                return;

            if (efs.TypEFS == TypPaska.DEP)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    #region obsluga prawego klika - edycja czasu

                    TimeEdit ti;
                    ti = new TimeEdit(m_time);
                    
                    if (efs.m_colorDepRectTime == Color.LimeGreen)
                    {
                        ti.ShowDialog();

                        if (ti.DialogResult == DialogResult.OK)
                        {
                            m_pushbackTime = ti.Time;
                            m_time = m_pushbackTime;
                        }
                    }
                    else if (efs.m_colorDepRectTime == Color.LightGreen)
                    {
                        ti.ShowDialog();

                        if (ti.DialogResult == DialogResult.OK)
                        {
                            m_startupTime = ti.Time;
                            m_time = m_startupTime;
                        }
                    }
                    else if (efs.m_colorDepRectTime == Color.White)
                    {
                        ti.ShowDialog();

                        if (ti.DialogResult == DialogResult.OK)
                        {
                            m_clearanceTime = ti.Time;
                            m_time = m_clearanceTime;
                        }
                    }
                    #endregion

                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    #region obsluga lewego klika
                    if (efs.m_colorDepRectTime == Color.LightBlue)
                    {
                        efs.m_colorDepRectTime = Color.White;
                        efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                        efs.m_clearanceTime = m_time;
                    }
                    else if (m_colorDepRectTime == Color.White)
                    {
                        efs.m_colorDepRectTime = Color.LightGreen;
                        efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                        efs.m_startupTime = m_time;
                    }
                    else if (efs.m_colorDepRectTime == Color.LightGreen)
                    {
                        efs.m_colorDepRectTime = Color.LimeGreen;
                        efs.m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                        efs.m_pushbackTime = m_time;
                    }
                    #endregion
                }
            }
            else if (efs.TypEFS == TypPaska.ARR)
            {
                //TODO bez zmiany koloru wypisz godzine o ktorej byl GA
            }
            efs.Invalidate();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            #region klik w time
            if (e.X > 90 && e.X < 160 && e.Y > 30 && e.Y < 60)
            {
                doubleClickChecker.Stop();

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    #region obsluga prawego klika
                    if (this.m_colorDepRectTime == Color.LimeGreen)
                    {
                        this.m_colorDepRectTime = Color.LightGreen;
                        this.m_time = m_startupTime;
                        this.m_pushbackTime = "";
                    }
                    else if (this.m_colorDepRectTime == Color.LightGreen)
                    {
                        this.m_colorDepRectTime = Color.White;
                        this.m_time = m_clearanceTime;
                        this.m_startupTime = "";
                    }
                    else if (this.m_colorDepRectTime == Color.White)
                    {
                        this.m_colorDepRectTime = Color.LightBlue;
                        this.m_time = "";
                        this.m_clearanceTime = "";
                    }
                    #endregion
                }
            }
            #endregion

            #region klik w Clearance
            if (e.X > 160 && e.X < 220 & e.Y > 30 && e.Y < 60)
            {
                if (this.TypEFS == TypPaska.ARR)
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        pbGoAround.Visible = true;
                        m_time = Bay.czasCwiczenia.Hour.ToString("00") + Bay.czasCwiczenia.Minute.ToString("00");
                        m_colorArrRectTime = Color.Orange;

                    }
            }
            #endregion

            #region zabezpieczenie przed pozostawaniem pola callsign w brazowym kolorze
            if (m_colorDepRectCallsign == Color.Chocolate || m_colorArrRectCallsign == Color.Chocolate)
            {
                m_colorArrRectCallsign = m_tempColor;
                m_colorDepRectCallsign = m_tempColor;
            }
            #endregion


            this.Invalidate();
            base.OnMouseDoubleClick(e);
            
        }



        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            
            base.OnLocationChanged(e);
        }
        
        internal void HighlightWhileDragging()
        {
            Graphics gfx = this.CreateGraphics();
            m_colorDepRectCallsign = Color.SandyBrown;
            this.Invalidate();

        }

        public string GenerateInitString()
        {
            //metoda zwraca wartosci pol potrzebne przy uzupelnianiu paska po przeslaniu go przez TCP na inny komputer
            //
            //initString:
            // 0 - callsign
            // 1 - taxito
            // 2 - stand
            // 3 - clrstate
            // 4 - sidstar
            // 5 - freetext

            // more to come

            string clrstate;

            if (pbLineUp.Visible)
                clrstate = "lineup";
            else if (pbContApp.Visible)
                clrstate = "contApp";
            else if (pbLand.Visible)
                clrstate = "land";
            else if (pbTakeOff.Visible)
                clrstate = "takeOff";
            else if (pbGoAround.Visible)
                clrstate = "goAround";
            else
                clrstate = "empty";  //tzn nic nie ma, puste pole, pbBlank.visible = true;

            string stand;

            if (this.TypEFS == TypPaska.ARR)
                stand = this.m_arrStand;
            else 
                stand = this.m_startPos;

            return string.Format("{0};{1};{2};{3};{4};{5}", this.Callsign, this.m_taxiTo, stand, clrstate, this.m_route, this.m_freeText);
        }
        public void ProcessInitString(string[] inits)
        {
            //initString:
            // 0 - callsign
            // 1 - taxito
            // 2 - stand
            // 3 - clrstate
            // 4 - sidstar
            // more to come

            this.m_taxiTo = inits[1];

            if (this.TypEFS == TypPaska.DEP)
            {
                this.m_startPos = inits[2];
                this.m_route = inits[4];
            }
            else if (this.TypEFS == TypPaska.ARR)
            {
                this.m_arrStand = inits[2];
                this.m_route = inits[4];
            }

            switch (inits[3])
            {
                case "lineup":
                    pbLineUp.Visible = true;
                    break;
                case "contApp":
                    pbContApp.Visible = true;
                    break;
                case "land":
                    pbLand.Visible = true;
                    break;
                case "takeOff":
                    pbTakeOff.Visible = true;
                    break;
                case "goAround":
                    pbGoAround.Visible = true;
                    break;
                default:
                    pbBlank.Visible = true;
                    break;
            }

            this.m_freeText = inits[5];
            if (m_freeText != "")
                this.m_freeTextFilled = true;

            

        }


    }

    [Serializable]
    public struct LocalEFSData
    {
        public string Callsign;
        public string Typ;
        public string WakeTurb;

        public LocalEFSData(string call, string typ, string wake)
        {
            Callsign = call;
            Typ = typ;
            WakeTurb = wake;
        }

    }
}
