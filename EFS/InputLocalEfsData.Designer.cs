namespace EFS
{
    partial class InputLocalEfsData
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
            this.btnAcid = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtAcid = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAcid
            // 
            this.btnAcid.BackColor = System.Drawing.Color.Azure;
            this.btnAcid.Location = new System.Drawing.Point(6, 10);
            this.btnAcid.Name = "btnAcid";
            this.btnAcid.Size = new System.Drawing.Size(90, 23);
            this.btnAcid.TabIndex = 5;
            this.btnAcid.Text = "Acid";
            this.btnAcid.UseVisualStyleBackColor = false;
            this.btnAcid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.Azure;
            this.btnType.Location = new System.Drawing.Point(103, 10);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(45, 23);
            this.btnType.TabIndex = 6;
            this.btnType.Text = "Type";
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // btnW
            // 
            this.btnW.BackColor = System.Drawing.Color.Azure;
            this.btnW.Location = new System.Drawing.Point(154, 10);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(25, 23);
            this.btnW.TabIndex = 7;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = false;
            this.btnW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Azure;
            this.btnOk.Location = new System.Drawing.Point(6, 71);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(173, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtAcid
            // 
            this.txtAcid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAcid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAcid.Location = new System.Drawing.Point(6, 39);
            this.txtAcid.MaxLength = 7;
            this.txtAcid.Name = "txtAcid";
            this.txtAcid.Size = new System.Drawing.Size(90, 26);
            this.txtAcid.TabIndex = 1;
            this.txtAcid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // txtType
            // 
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtType.Location = new System.Drawing.Point(103, 39);
            this.txtType.MaxLength = 4;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(45, 26);
            this.txtType.TabIndex = 2;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // txtW
            // 
            this.txtW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtW.Location = new System.Drawing.Point(154, 39);
            this.txtW.MaxLength = 1;
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(25, 26);
            this.txtW.TabIndex = 3;
            this.txtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            // 
            // InputLocalEfsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(189, 103);
            this.ControlBox = false;
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtAcid);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.btnAcid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputLocalEfsData";
            this.Load += new System.EventHandler(this.InputLocalEfsData_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcid_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcid;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtAcid;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtW;
    }
}