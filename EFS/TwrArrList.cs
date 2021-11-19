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
    public partial class TwrArrList : Form
    {
        public Bay FormaBazowa { get; set; }
        private List<StripSmall> SmallStripList = new List<StripSmall>();

        public TwrArrList()
        {
            InitializeComponent();
        }


        public void PopulateArrList(List<Strip> StripList)
        {
            foreach (Strip efs in StripList)
            {

                StripSmall efsSmall = new StripSmall(efs);
                efsSmall.myBay = FormaBazowa;
                efsSmall.myTwrArrList = this;
                pnlPendingArr.Controls.Add(efsSmall);
                
            }   
        }

        public void AddSmallStrip(StripSmall smallEfs)
        {
            smallEfs.myBay = FormaBazowa;
            smallEfs.myTwrArrList = this;
            pnlPendingArr.Controls.Add(smallEfs);
            pnlPendingArr.Controls.SetChildIndex(smallEfs, 0);

        }

        private void TwrArrList_FormClosing(object sender, FormClosingEventArgs e)
        {  
            if (e.CloseReason == CloseReason.UserClosing) 
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void removeFromPnl(StripSmall smallEfs)
        {
            foreach (StripSmall ss in pnlPendingArr.Controls)
            {
                if (ss.Callsign == smallEfs.Callsign)
                    pnlPendingArr.Controls.Remove(ss);
            }

        }

        private void TwrArrList_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FormaBazowa.Location.X + 1100, 10);
        }

        public void ClearList()
        {
            pnlPendingArr.Controls.Clear();
        }

       


        



        //protected override void WndProc(ref Message message)
        //{
        //    //ten kawalek kodu zapobiega przesuwaniu okna twr arr (pending)
        //    //a zrobilem to dlatego ze jak uzytkownik przeciaga okno po glownej 
        //    //formie Bay to to wpada pod inne kontrolki i nie wiem jak temu zapobiec :D

        //    const int WM_SYSCOMMAND = 0x0112;
        //    const int SC_MOVE = 0xF010;

        //    switch (message.Msg)
        //    {
        //        case WM_SYSCOMMAND:
        //            int command = message.WParam.ToInt32() & 0xfff0;
        //            if (command == SC_MOVE)
        //                return;
        //            break;
        //    }

        //    base.WndProc(ref message);
        //}

       
    }
}
