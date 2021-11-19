using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFS
{
    public partial class StripSmall : UserControl
    {

        #region fields
        private string m_callsign;
        public string m_eta;
        private string m_type;
        private string m_route;
        private string m_wakeTurb;
        private FlightPlan m_flightPlan;
        private Strip m_strip;

        public Bay myBay { get; set; }
        public TwrArrList myTwrArrList { get; set; }
        public Bin myBin { get; set; }

        #endregion

        #region properties
        public FlightPlan GetFPL { get { return m_flightPlan; } }
        public string Callsign
        {
            get { return m_callsign; }
        }
        public Strip GetStrip { get { return m_strip; } }

        #endregion

        #region graphics
        private Rectangle rectAct = new Rectangle(3, 3, 40, 18);
        #endregion

        #region events
        public event EventHandler ActClicked;
        #endregion



        public StripSmall()
        {
            InitializeComponent();
        }

        public StripSmall(FlightPlan fpl)
        {
            InitializeComponent();
            this.m_flightPlan = fpl;
            this.m_callsign = fpl.Callsign;
            this.m_eta = fpl.StartTime;
            this.m_type = fpl.Typ;
            this.m_route = fpl.Route;
            this.m_wakeTurb = fpl.WakeTurbCat;

            lblCs.Text = this.m_callsign;
            lblTypeWake.Text = this.m_type + "/" + this.m_wakeTurb;
            lblRoute.Text = this.m_route;
            lblEta.Text = this.m_eta;
        }

        public StripSmall(Strip strip)
        {
            InitializeComponent();
            this.m_flightPlan = strip.FPL;
            this.m_callsign = strip.Callsign;
            this.m_eta = strip.m_eobt;
            this.m_type = strip.ACType;
            this.m_route = strip.Route;
            this.m_wakeTurb = strip.WakeTurb;
            this.m_strip = strip;

            lblCs.Text = this.m_callsign;
            lblTypeWake.Text = this.m_type + "/" + this.m_wakeTurb;
            lblRoute.Text = this.m_route;
            lblEta.Text = this.m_eta;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
 	        base.OnPaint(e);
            Graphics gfx = this.CreateGraphics();

            Pen myPen = new Pen(Color.Black);
            gfx.DrawRectangle(myPen, rectAct);

            Rectangle border = ClientRectangle;
            border.Size = new Size(border.Width - 1, border.Height - 1);
            gfx.DrawRectangle(myPen, border);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.X > 3 && e.X < 43 && e.Y > 3 && e.Y < 21)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //sprawdzam z jakiego okna zostal wywolany event
                    if (this.Parent.Name == "pnlPendingArr")
                    {
                        myBay.addArrStrip(this.GetStrip);
                        myTwrArrList.removeFromPnl(this);
                    }
                    else if (this.Parent.Name == "pnlBin")
                    {
                        foreach (Control c in myBay.Controls)
                        {
                            if (c.GetType() == typeof(FlowLayoutPanel))
                            {
                                FlowLayoutPanel pnl = (FlowLayoutPanel)c;
                                if (pnl == this.GetStrip.UsunieteZ)
                                {
                                    pnl.Controls.Add(this.GetStrip);
                                }
                            }
                        }
                        myBin.removeFromPnl(this);

                    }
                }
            }
            base.OnMouseClick(e);
        }
    }
}
