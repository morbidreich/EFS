namespace EFS
{
    partial class StripSmall
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCs = new System.Windows.Forms.Label();
            this.lblTypeWake = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblEta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCs
            // 
            this.lblCs.AutoSize = true;
            this.lblCs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCs.Location = new System.Drawing.Point(51, 4);
            this.lblCs.Name = "lblCs";
            this.lblCs.Size = new System.Drawing.Size(49, 15);
            this.lblCs.TabIndex = 0;
            this.lblCs.Text = "label1";
            // 
            // lblTypeWake
            // 
            this.lblTypeWake.AutoSize = true;
            this.lblTypeWake.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTypeWake.Location = new System.Drawing.Point(123, 4);
            this.lblTypeWake.Name = "lblTypeWake";
            this.lblTypeWake.Size = new System.Drawing.Size(49, 15);
            this.lblTypeWake.TabIndex = 1;
            this.lblTypeWake.Text = "label2";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRoute.Location = new System.Drawing.Point(195, 4);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(49, 15);
            this.lblRoute.TabIndex = 2;
            this.lblRoute.Text = "label3";
            // 
            // lblEta
            // 
            this.lblEta.AutoSize = true;
            this.lblEta.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEta.Location = new System.Drawing.Point(259, 4);
            this.lblEta.Name = "lblEta";
            this.lblEta.Size = new System.Drawing.Size(49, 15);
            this.lblEta.TabIndex = 3;
            this.lblEta.Text = "label4";
            // 
            // StripSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEta);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.lblTypeWake);
            this.Controls.Add(this.lblCs);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "StripSmall";
            this.Size = new System.Drawing.Size(311, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCs;
        private System.Windows.Forms.Label lblTypeWake;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblEta;
    }
}
