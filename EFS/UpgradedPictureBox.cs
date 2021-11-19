using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFS
{
    public class UpgradedPictureBox : System.Windows.Forms.PictureBox
    {
        // znalezione w necie, metoda na latwiejsze obsluzenie i odroznienie single i doubleclick
        //
        //
        //http://stackoverflow.com/questions/20132136/picture-box-double-click-single-click-events

        // Note that the DoubleClickTime property gets 
        // the maximum number of milliseconds allowed between 
        // mouse clicks for a double-click to be valid.
        int previousClick = SystemInformation.DoubleClickTime;
        public new event EventHandler DoubleClick;

        protected override void OnClick(EventArgs e)
        {
            int now = System.Environment.TickCount;
            // A double-click is detected if the the time elapsed
            // since the last click is within DoubleClickTime.
            if (now - previousClick <= SystemInformation.DoubleClickTime)
            {
                // Raise the DoubleClick event.
                if (DoubleClick != null)
                    DoubleClick(this, EventArgs.Empty);
            }
            // Set previousClick to now so that 
            // subsequent double-clicks can be detected.
            previousClick = now;
            // Allow the base class to raise the regular Click event.
            base.OnClick(e);
        }

        // Event handling code for the DoubleClick event.
        protected new virtual void OnDoubleClick(EventArgs e)
        {
            if (this.DoubleClick != null)
                this.DoubleClick(this, e);
        }
    }
}
