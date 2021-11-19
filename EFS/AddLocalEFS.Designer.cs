namespace EFS
{
    partial class AddLocalEFS
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
            this.btnCnl = new System.Windows.Forms.Button();
            this.btnDep = new System.Windows.Forms.Button();
            this.btnArr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCnl
            // 
            this.btnCnl.Location = new System.Drawing.Point(507, 107);
            this.btnCnl.Name = "btnCnl";
            this.btnCnl.Size = new System.Drawing.Size(40, 40);
            this.btnCnl.TabIndex = 3;
            this.btnCnl.Text = "CNL";
            this.btnCnl.UseVisualStyleBackColor = true;
            this.btnCnl.Click += new System.EventHandler(this.btnCnl_Click);
            // 
            // btnDep
            // 
            this.btnDep.Location = new System.Drawing.Point(507, 12);
            this.btnDep.Name = "btnDep";
            this.btnDep.Size = new System.Drawing.Size(40, 40);
            this.btnDep.TabIndex = 2;
            this.btnDep.Text = "DEP";
            this.btnDep.UseVisualStyleBackColor = true;
            this.btnDep.Click += new System.EventHandler(this.btnDep_Click);
            // 
            // btnArr
            // 
            this.btnArr.Location = new System.Drawing.Point(507, 58);
            this.btnArr.Name = "btnArr";
            this.btnArr.Size = new System.Drawing.Size(40, 40);
            this.btnArr.TabIndex = 4;
            this.btnArr.Text = "ARR";
            this.btnArr.UseVisualStyleBackColor = true;
            this.btnArr.Click += new System.EventHandler(this.btnArr_Click);
            // 
            // AddLocalEFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(559, 162);
            this.Controls.Add(this.btnArr);
            this.Controls.Add(this.btnCnl);
            this.Controls.Add(this.btnDep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddLocalEFS";
            this.Text = "Add Local EFS";
            this.Load += new System.EventHandler(this.AddLocalEFS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCnl;
        private System.Windows.Forms.Button btnDep;
        private System.Windows.Forms.Button btnArr;

    }
}