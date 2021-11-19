namespace EFS
{
    partial class SidWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstHdg = new System.Windows.Forms.ListBox();
            this.lstLvl = new System.Windows.Forms.ListBox();
            this.lstSid = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHdg
            // 
            this.lstHdg.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstHdg.FormattingEnabled = true;
            this.lstHdg.Location = new System.Drawing.Point(150, 31);
            this.lstHdg.Name = "lstHdg";
            this.lstHdg.Size = new System.Drawing.Size(65, 173);
            this.lstHdg.TabIndex = 0;
            this.lstHdg.SelectedIndexChanged += new System.EventHandler(this.lstHdg_SelectedIndexChanged);
            // 
            // lstLvl
            // 
            this.lstLvl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstLvl.FormattingEnabled = true;
            this.lstLvl.Location = new System.Drawing.Point(221, 31);
            this.lstLvl.Name = "lstLvl";
            this.lstLvl.Size = new System.Drawing.Size(65, 173);
            this.lstLvl.TabIndex = 1;
            this.lstLvl.SelectedIndexChanged += new System.EventHandler(this.lstLvl_SelectedIndexChanged);
            // 
            // lstSid
            // 
            this.lstSid.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstSid.FormattingEnabled = true;
            this.lstSid.Location = new System.Drawing.Point(3, 31);
            this.lstSid.Name = "lstSid";
            this.lstSid.Size = new System.Drawing.Size(141, 173);
            this.lstSid.TabIndex = 2;
            this.lstSid.SelectedIndexChanged += new System.EventHandler(this.lstSid_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "SID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Heading";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Level";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SidWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(300, 216);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstSid);
            this.Controls.Add(this.lstLvl);
            this.Controls.Add(this.lstHdg);
            this.Name = "SidWindow";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SID_Load);
            this.Shown += new System.EventHandler(this.SidWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstHdg;
        private System.Windows.Forms.ListBox lstLvl;
        private System.Windows.Forms.ListBox lstSid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}