namespace EFS
{
    partial class DodajPasek
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radInfo = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radDep = new System.Windows.Forms.RadioButton();
            this.radArr = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlInfostrip = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlArr = new System.Windows.Forms.Panel();
            this.radS = new System.Windows.Forms.RadioButton();
            this.radA = new System.Windows.Forms.RadioButton();
            this.radC = new System.Windows.Forms.RadioButton();
            this.radN = new System.Windows.Forms.RadioButton();
            this.txtRFL = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.txtSquawk = new System.Windows.Forms.TextBox();
            this.txtADEST = new System.Windows.Forms.TextBox();
            this.txtADEP = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tx = new System.Windows.Forms.Label();
            this.lblAdest = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlInfostrip.SuspendLayout();
            this.pnlArr.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radInfo);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radDep);
            this.groupBox1.Controls.Add(this.radArr);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EFS type";
            // 
            // radInfo
            // 
            this.radInfo.AutoSize = true;
            this.radInfo.Checked = true;
            this.radInfo.Location = new System.Drawing.Point(190, 20);
            this.radInfo.Name = "radInfo";
            this.radInfo.Size = new System.Drawing.Size(43, 17);
            this.radInfo.TabIndex = 3;
            this.radInfo.TabStop = true;
            this.radInfo.Text = "Info";
            this.radInfo.UseVisualStyleBackColor = true;
            this.radInfo.CheckedChanged += new System.EventHandler(this.radArr_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(114, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Overflight";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radArr_CheckedChanged);
            // 
            // radDep
            // 
            this.radDep.AutoSize = true;
            this.radDep.Enabled = false;
            this.radDep.Location = new System.Drawing.Point(61, 19);
            this.radDep.Name = "radDep";
            this.radDep.Size = new System.Drawing.Size(47, 17);
            this.radDep.TabIndex = 1;
            this.radDep.Text = "DEP";
            this.radDep.UseVisualStyleBackColor = true;
            this.radDep.CheckedChanged += new System.EventHandler(this.radArr_CheckedChanged);
            // 
            // radArr
            // 
            this.radArr.AutoSize = true;
            this.radArr.Enabled = false;
            this.radArr.Location = new System.Drawing.Point(7, 20);
            this.radArr.Name = "radArr";
            this.radArr.Size = new System.Drawing.Size(48, 17);
            this.radArr.TabIndex = 0;
            this.radArr.Text = "ARR";
            this.radArr.UseVisualStyleBackColor = true;
            this.radArr.CheckedChanged += new System.EventHandler(this.radArr_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj pasek";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlInfostrip
            // 
            this.pnlInfostrip.Controls.Add(this.textBox1);
            this.pnlInfostrip.Controls.Add(this.label1);
            this.pnlInfostrip.Location = new System.Drawing.Point(13, 72);
            this.pnlInfostrip.Name = "pnlInfostrip";
            this.pnlInfostrip.Size = new System.Drawing.Size(315, 66);
            this.pnlInfostrip.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FreeText";
            // 
            // pnlArr
            // 
            this.pnlArr.Controls.Add(this.radS);
            this.pnlArr.Controls.Add(this.radA);
            this.pnlArr.Controls.Add(this.radC);
            this.pnlArr.Controls.Add(this.radN);
            this.pnlArr.Controls.Add(this.txtRFL);
            this.pnlArr.Controls.Add(this.txtRoute);
            this.pnlArr.Controls.Add(this.txtSquawk);
            this.pnlArr.Controls.Add(this.txtADEST);
            this.pnlArr.Controls.Add(this.txtADEP);
            this.pnlArr.Controls.Add(this.txtType);
            this.pnlArr.Controls.Add(this.txtCallsign);
            this.pnlArr.Controls.Add(this.label9);
            this.pnlArr.Controls.Add(this.txt);
            this.pnlArr.Controls.Add(this.label7);
            this.pnlArr.Controls.Add(this.tx);
            this.pnlArr.Controls.Add(this.lblAdest);
            this.pnlArr.Controls.Add(this.label4);
            this.pnlArr.Controls.Add(this.label3);
            this.pnlArr.Controls.Add(this.label2);
            this.pnlArr.Enabled = false;
            this.pnlArr.Location = new System.Drawing.Point(13, 144);
            this.pnlArr.Name = "pnlArr";
            this.pnlArr.Size = new System.Drawing.Size(315, 195);
            this.pnlArr.TabIndex = 3;
            // 
            // radS
            // 
            this.radS.Appearance = System.Windows.Forms.Appearance.Button;
            this.radS.AutoSize = true;
            this.radS.Location = new System.Drawing.Point(268, 42);
            this.radS.Name = "radS";
            this.radS.Size = new System.Drawing.Size(24, 23);
            this.radS.TabIndex = 18;
            this.radS.Text = "S";
            this.radS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radS.UseVisualStyleBackColor = true;
            // 
            // radA
            // 
            this.radA.Appearance = System.Windows.Forms.Appearance.Button;
            this.radA.AutoSize = true;
            this.radA.Location = new System.Drawing.Point(212, 42);
            this.radA.Name = "radA";
            this.radA.Size = new System.Drawing.Size(24, 23);
            this.radA.TabIndex = 17;
            this.radA.Text = "A";
            this.radA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radA.UseVisualStyleBackColor = true;
            // 
            // radC
            // 
            this.radC.Appearance = System.Windows.Forms.Appearance.Button;
            this.radC.AutoSize = true;
            this.radC.Checked = true;
            this.radC.Location = new System.Drawing.Point(240, 42);
            this.radC.Name = "radC";
            this.radC.Size = new System.Drawing.Size(24, 23);
            this.radC.TabIndex = 16;
            this.radC.TabStop = true;
            this.radC.Text = "C";
            this.radC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radC.UseVisualStyleBackColor = true;
            // 
            // radN
            // 
            this.radN.Appearance = System.Windows.Forms.Appearance.Button;
            this.radN.AutoSize = true;
            this.radN.Location = new System.Drawing.Point(183, 42);
            this.radN.Name = "radN";
            this.radN.Size = new System.Drawing.Size(25, 23);
            this.radN.TabIndex = 15;
            this.radN.Text = "N";
            this.radN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radN.UseVisualStyleBackColor = true;
            // 
            // txtRFL
            // 
            this.txtRFL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFL.Location = new System.Drawing.Point(71, 136);
            this.txtRFL.MaxLength = 5;
            this.txtRFL.Name = "txtRFL";
            this.txtRFL.Size = new System.Drawing.Size(69, 20);
            this.txtRFL.TabIndex = 13;
            // 
            // txtRoute
            // 
            this.txtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRoute.Location = new System.Drawing.Point(71, 161);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(195, 20);
            this.txtRoute.TabIndex = 14;
            // 
            // txtSquawk
            // 
            this.txtSquawk.Location = new System.Drawing.Point(71, 111);
            this.txtSquawk.MaxLength = 4;
            this.txtSquawk.Name = "txtSquawk";
            this.txtSquawk.Size = new System.Drawing.Size(69, 20);
            this.txtSquawk.TabIndex = 12;
            this.txtSquawk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSquawk_KeyPress);
            // 
            // txtADEST
            // 
            this.txtADEST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtADEST.Location = new System.Drawing.Point(71, 86);
            this.txtADEST.MaxLength = 4;
            this.txtADEST.Name = "txtADEST";
            this.txtADEST.Size = new System.Drawing.Size(69, 20);
            this.txtADEST.TabIndex = 11;
            // 
            // txtADEP
            // 
            this.txtADEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtADEP.Location = new System.Drawing.Point(71, 61);
            this.txtADEP.MaxLength = 4;
            this.txtADEP.Name = "txtADEP";
            this.txtADEP.Size = new System.Drawing.Size(69, 20);
            this.txtADEP.TabIndex = 10;
            // 
            // txtType
            // 
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Location = new System.Drawing.Point(71, 36);
            this.txtType.MaxLength = 4;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(69, 20);
            this.txtType.TabIndex = 9;
            // 
            // txtCallsign
            // 
            this.txtCallsign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCallsign.Location = new System.Drawing.Point(71, 11);
            this.txtCallsign.MaxLength = 7;
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(69, 20);
            this.txtCallsign.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "RFL";
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(13, 164);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(36, 13);
            this.txt.TabIndex = 6;
            this.txt.Text = "Route";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Transponder capability";
            // 
            // tx
            // 
            this.tx.AutoSize = true;
            this.tx.Location = new System.Drawing.Point(13, 114);
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(46, 13);
            this.tx.TabIndex = 4;
            this.tx.Text = "Squawk";
            // 
            // lblAdest
            // 
            this.lblAdest.AutoSize = true;
            this.lblAdest.BackColor = System.Drawing.SystemColors.Control;
            this.lblAdest.Location = new System.Drawing.Point(13, 89);
            this.lblAdest.Name = "lblAdest";
            this.lblAdest.Size = new System.Drawing.Size(43, 13);
            this.lblAdest.TabIndex = 3;
            this.lblAdest.Text = "ADEST";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "ADEP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Callsign";
            // 
            // DodajPasek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 407);
            this.Controls.Add(this.pnlArr);
            this.Controls.Add(this.pnlInfostrip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DodajPasek";
            this.Text = "DodajPasek";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlInfostrip.ResumeLayout(false);
            this.pnlInfostrip.PerformLayout();
            this.pnlArr.ResumeLayout(false);
            this.pnlArr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radInfo;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radDep;
        private System.Windows.Forms.RadioButton radArr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlInfostrip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlArr;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.TextBox txtSquawk;
        private System.Windows.Forms.TextBox txtADEST;
        private System.Windows.Forms.TextBox txtADEP;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tx;
        private System.Windows.Forms.Label lblAdest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radS;
        private System.Windows.Forms.RadioButton radA;
        private System.Windows.Forms.RadioButton radC;
        private System.Windows.Forms.RadioButton radN;
        private System.Windows.Forms.TextBox txtRFL;
    }
}