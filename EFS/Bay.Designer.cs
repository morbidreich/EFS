namespace EFS
{
    partial class Bay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bay));
            this.pendingDepBay = new System.Windows.Forms.FlowLayoutPanel();
            this.taxiBay = new System.Windows.Forms.FlowLayoutPanel();
            this.rwyBay = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRunwaySeparator = new System.Windows.Forms.Panel();
            this.lblRunwaySeparator = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konfiguracjaRwyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajPasekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjdźToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCzas = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblCzas = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bin = new System.Windows.Forms.Button();
            this.pnlAirborneSeparator = new System.Windows.Forms.Panel();
            this.lblAirborneSeparator = new System.Windows.Forms.Label();
            this.airborneBay = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTaxiSeparator = new System.Windows.Forms.Panel();
            this.lblTaxiSeparator = new System.Windows.Forms.Label();
            this.beforeTaxiBay = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPdg = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnLocalEFS = new System.Windows.Forms.Button();
            this.btnObstSymb = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNetStop = new System.Windows.Forms.Button();
            this.btnNetStart = new System.Windows.Forms.Button();
            this.radGnd = new System.Windows.Forms.RadioButton();
            this.radTwr = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnTwrGnd = new System.Windows.Forms.Button();
            this.pnlRunwaySeparator.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlCzas.SuspendLayout();
            this.pnlAirborneSeparator.SuspendLayout();
            this.pnlTaxiSeparator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pendingDepBay
            // 
            this.pendingDepBay.AllowDrop = true;
            this.pendingDepBay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pendingDepBay.AutoScroll = true;
            this.pendingDepBay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pendingDepBay.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.pendingDepBay.Location = new System.Drawing.Point(16, 124);
            this.pendingDepBay.Margin = new System.Windows.Forms.Padding(4);
            this.pendingDepBay.Name = "pendingDepBay";
            this.pendingDepBay.Size = new System.Drawing.Size(633, 536);
            this.pendingDepBay.TabIndex = 8;
            this.pendingDepBay.WrapContents = false;
            this.pendingDepBay.DragOver += new System.Windows.Forms.DragEventHandler(this.bay_DragOver);
            this.pendingDepBay.DragLeave += new System.EventHandler(this.bay_DragLeave);
            // 
            // taxiBay
            // 
            this.taxiBay.AllowDrop = true;
            this.taxiBay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.taxiBay.AutoScroll = true;
            this.taxiBay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.taxiBay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.taxiBay.Location = new System.Drawing.Point(680, 540);
            this.taxiBay.Margin = new System.Windows.Forms.Padding(4);
            this.taxiBay.Name = "taxiBay";
            this.taxiBay.Size = new System.Drawing.Size(633, 155);
            this.taxiBay.TabIndex = 9;
            this.taxiBay.WrapContents = false;
            this.taxiBay.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.taxiBay_ControlAdded);
            this.taxiBay.DragOver += new System.Windows.Forms.DragEventHandler(this.bay_DragOver);
            this.taxiBay.DragLeave += new System.EventHandler(this.bay_DragLeave);
            // 
            // rwyBay
            // 
            this.rwyBay.AllowDrop = true;
            this.rwyBay.AutoScroll = true;
            this.rwyBay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rwyBay.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.rwyBay.Location = new System.Drawing.Point(680, 362);
            this.rwyBay.Margin = new System.Windows.Forms.Padding(4);
            this.rwyBay.Name = "rwyBay";
            this.rwyBay.Size = new System.Drawing.Size(633, 157);
            this.rwyBay.TabIndex = 10;
            this.rwyBay.WrapContents = false;
            this.rwyBay.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.rwyBay_ControlAdded);
            this.rwyBay.DragOver += new System.Windows.Forms.DragEventHandler(this.bay_DragOver);
            this.rwyBay.DragLeave += new System.EventHandler(this.bay_DragLeave);
            // 
            // pnlRunwaySeparator
            // 
            this.pnlRunwaySeparator.BackColor = System.Drawing.Color.Lime;
            this.pnlRunwaySeparator.Controls.Add(this.lblRunwaySeparator);
            this.pnlRunwaySeparator.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pnlRunwaySeparator.Location = new System.Drawing.Point(681, 521);
            this.pnlRunwaySeparator.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRunwaySeparator.Name = "pnlRunwaySeparator";
            this.pnlRunwaySeparator.Size = new System.Drawing.Size(600, 18);
            this.pnlRunwaySeparator.TabIndex = 12;
            this.pnlRunwaySeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlRunwaySeparator_MouseMove);
            // 
            // lblRunwaySeparator
            // 
            this.lblRunwaySeparator.AutoSize = true;
            this.lblRunwaySeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRunwaySeparator.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRunwaySeparator.Location = new System.Drawing.Point(233, 0);
            this.lblRunwaySeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRunwaySeparator.Name = "lblRunwaySeparator";
            this.lblRunwaySeparator.Size = new System.Drawing.Size(135, 20);
            this.lblRunwaySeparator.TabIndex = 1;
            this.lblRunwaySeparator.Text = "    RUNWAY    ";
            this.lblRunwaySeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlRunwaySeparator_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajToolStripMenuItem,
            this.konfiguracjaRwyToolStripMenuItem,
            this.dodajPasekToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.wyjdźToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1451, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.wczytajToolStripMenuItem.Text = "Wczytaj cwiczenie";
            this.wczytajToolStripMenuItem.Click += new System.EventHandler(this.wczytajToolStripMenuItem_Click);
            // 
            // konfiguracjaRwyToolStripMenuItem
            // 
            this.konfiguracjaRwyToolStripMenuItem.Enabled = false;
            this.konfiguracjaRwyToolStripMenuItem.Name = "konfiguracjaRwyToolStripMenuItem";
            this.konfiguracjaRwyToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.konfiguracjaRwyToolStripMenuItem.Text = "Konfiguracja RWY";
            this.konfiguracjaRwyToolStripMenuItem.Click += new System.EventHandler(this.konfiguracjaRwyToolStripMenuItem_Click);
            // 
            // dodajPasekToolStripMenuItem
            // 
            this.dodajPasekToolStripMenuItem.Name = "dodajPasekToolStripMenuItem";
            this.dodajPasekToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.dodajPasekToolStripMenuItem.Text = "Dodaj pasek";
            this.dodajPasekToolStripMenuItem.Click += new System.EventHandler(this.dodajPasekToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // wyjdźToolStripMenuItem
            // 
            this.wyjdźToolStripMenuItem.Name = "wyjdźToolStripMenuItem";
            this.wyjdźToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.wyjdźToolStripMenuItem.Text = "Wyjdź";
            this.wyjdźToolStripMenuItem.Click += new System.EventHandler(this.wyjdźToolStripMenuItem_Click);
            // 
            // pnlCzas
            // 
            this.pnlCzas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCzas.Controls.Add(this.button8);
            this.pnlCzas.Controls.Add(this.button7);
            this.pnlCzas.Controls.Add(this.button6);
            this.pnlCzas.Controls.Add(this.button5);
            this.pnlCzas.Controls.Add(this.button4);
            this.pnlCzas.Controls.Add(this.button3);
            this.pnlCzas.Controls.Add(this.lblCzas);
            this.pnlCzas.Controls.Add(this.button2);
            this.pnlCzas.Controls.Add(this.button1);
            this.pnlCzas.Enabled = false;
            this.pnlCzas.Location = new System.Drawing.Point(16, 844);
            this.pnlCzas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCzas.Name = "pnlCzas";
            this.pnlCzas.Size = new System.Drawing.Size(376, 149);
            this.pnlCzas.TabIndex = 17;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(297, 123);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(27, 25);
            this.button8.TabIndex = 25;
            this.button8.Text = "-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(213, 123);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(27, 25);
            this.button7.TabIndex = 24;
            this.button7.Text = "-";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(297, 28);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(27, 25);
            this.button6.TabIndex = 23;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(213, 28);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 22;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(112, 123);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 25);
            this.button4.TabIndex = 21;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(113, 28);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 25);
            this.button3.TabIndex = 20;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblCzas
            // 
            this.lblCzas.AutoSize = true;
            this.lblCzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCzas.Location = new System.Drawing.Point(84, 54);
            this.lblCzas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCzas.Name = "lblCzas";
            this.lblCzas.Size = new System.Drawing.Size(262, 69);
            this.lblCzas.TabIndex = 19;
            this.lblCzas.Text = "00:00:00";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(9, 86);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 62);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::EFS.Properties.Resources.play1;
            this.button1.Location = new System.Drawing.Point(9, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 62);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bin
            // 
            this.bin.AllowDrop = true;
            this.bin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bin.Location = new System.Drawing.Point(1323, 916);
            this.bin.Margin = new System.Windows.Forms.Padding(4);
            this.bin.Name = "bin";
            this.bin.Size = new System.Drawing.Size(116, 84);
            this.bin.TabIndex = 15;
            this.bin.Text = "BIN";
            this.bin.UseVisualStyleBackColor = true;
            this.bin.Click += new System.EventHandler(this.bin_Click);
            // 
            // pnlAirborneSeparator
            // 
            this.pnlAirborneSeparator.BackColor = System.Drawing.Color.Lime;
            this.pnlAirborneSeparator.Controls.Add(this.lblAirborneSeparator);
            this.pnlAirborneSeparator.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pnlAirborneSeparator.Location = new System.Drawing.Point(680, 342);
            this.pnlAirborneSeparator.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAirborneSeparator.Name = "pnlAirborneSeparator";
            this.pnlAirborneSeparator.Size = new System.Drawing.Size(600, 18);
            this.pnlAirborneSeparator.TabIndex = 13;
            this.pnlAirborneSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlAirborneSeparator_MouseMove);
            // 
            // lblAirborneSeparator
            // 
            this.lblAirborneSeparator.AutoSize = true;
            this.lblAirborneSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAirborneSeparator.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAirborneSeparator.Location = new System.Drawing.Point(233, 0);
            this.lblAirborneSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAirborneSeparator.Name = "lblAirborneSeparator";
            this.lblAirborneSeparator.Size = new System.Drawing.Size(135, 20);
            this.lblAirborneSeparator.TabIndex = 0;
            this.lblAirborneSeparator.Text = "   AIRBORNE   ";
            this.lblAirborneSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlAirborneSeparator_MouseMove);
            // 
            // airborneBay
            // 
            this.airborneBay.AutoScroll = true;
            this.airborneBay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.airborneBay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.airborneBay.Location = new System.Drawing.Point(680, 33);
            this.airborneBay.Margin = new System.Windows.Forms.Padding(4);
            this.airborneBay.Name = "airborneBay";
            this.airborneBay.Size = new System.Drawing.Size(633, 307);
            this.airborneBay.TabIndex = 18;
            this.airborneBay.WrapContents = false;
            this.airborneBay.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.airborneBay_ControlAdded);
            this.airborneBay.DragOver += new System.Windows.Forms.DragEventHandler(this.bay_DragOver);
            this.airborneBay.DragLeave += new System.EventHandler(this.bay_DragLeave);
            // 
            // pnlTaxiSeparator
            // 
            this.pnlTaxiSeparator.BackColor = System.Drawing.Color.Lime;
            this.pnlTaxiSeparator.Controls.Add(this.lblTaxiSeparator);
            this.pnlTaxiSeparator.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pnlTaxiSeparator.Location = new System.Drawing.Point(680, 736);
            this.pnlTaxiSeparator.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTaxiSeparator.Name = "pnlTaxiSeparator";
            this.pnlTaxiSeparator.Size = new System.Drawing.Size(600, 18);
            this.pnlTaxiSeparator.TabIndex = 13;
            this.pnlTaxiSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTaxiSeparator_MouseMove);
            // 
            // lblTaxiSeparator
            // 
            this.lblTaxiSeparator.AutoSize = true;
            this.lblTaxiSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTaxiSeparator.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTaxiSeparator.Location = new System.Drawing.Point(233, 0);
            this.lblTaxiSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaxiSeparator.Name = "lblTaxiSeparator";
            this.lblTaxiSeparator.Size = new System.Drawing.Size(135, 20);
            this.lblTaxiSeparator.TabIndex = 1;
            this.lblTaxiSeparator.Text = "     TAXI     ";
            this.lblTaxiSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTaxiSeparator_MouseMove);
            // 
            // beforeTaxiBay
            // 
            this.beforeTaxiBay.AllowDrop = true;
            this.beforeTaxiBay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.beforeTaxiBay.AutoScroll = true;
            this.beforeTaxiBay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.beforeTaxiBay.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.beforeTaxiBay.Location = new System.Drawing.Point(681, 756);
            this.beforeTaxiBay.Margin = new System.Windows.Forms.Padding(4);
            this.beforeTaxiBay.Name = "beforeTaxiBay";
            this.beforeTaxiBay.Size = new System.Drawing.Size(633, 243);
            this.beforeTaxiBay.TabIndex = 10;
            this.beforeTaxiBay.WrapContents = false;
            this.beforeTaxiBay.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.BeforeTaxiBay_ControlAdded);
            this.beforeTaxiBay.DragOver += new System.Windows.Forms.DragEventHandler(this.bay_DragOver);
            this.beforeTaxiBay.DragLeave += new System.EventHandler(this.bay_DragLeave);
            // 
            // btnPdg
            // 
            this.btnPdg.AllowDrop = true;
            this.btnPdg.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPdg.Location = new System.Drawing.Point(1323, 33);
            this.btnPdg.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdg.Name = "btnPdg";
            this.btnPdg.Size = new System.Drawing.Size(116, 84);
            this.btnPdg.TabIndex = 19;
            this.btnPdg.Text = "PDG";
            this.btnPdg.UseVisualStyleBackColor = true;
            this.btnPdg.Click += new System.EventHandler(this.btnPdg_Click);
            // 
            // button9
            // 
            this.button9.AllowDrop = true;
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button9.Location = new System.Drawing.Point(1323, 782);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(116, 84);
            this.button9.TabIndex = 20;
            this.button9.Text = "D-I";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            // 
            // btnLocalEFS
            // 
            this.btnLocalEFS.AllowDrop = true;
            this.btnLocalEFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLocalEFS.Location = new System.Drawing.Point(128, 33);
            this.btnLocalEFS.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocalEFS.Name = "btnLocalEFS";
            this.btnLocalEFS.Size = new System.Drawing.Size(116, 84);
            this.btnLocalEFS.TabIndex = 21;
            this.btnLocalEFS.Text = "local EFS";
            this.btnLocalEFS.UseVisualStyleBackColor = true;
            this.btnLocalEFS.Click += new System.EventHandler(this.btnLocalEFS_Click);
            // 
            // btnObstSymb
            // 
            this.btnObstSymb.AllowDrop = true;
            this.btnObstSymb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnObstSymb.Location = new System.Drawing.Point(409, 33);
            this.btnObstSymb.Margin = new System.Windows.Forms.Padding(4);
            this.btnObstSymb.Name = "btnObstSymb";
            this.btnObstSymb.Size = new System.Drawing.Size(116, 84);
            this.btnObstSymb.TabIndex = 22;
            this.btnObstSymb.Text = "Obst. symb.";
            this.btnObstSymb.UseVisualStyleBackColor = true;
            this.btnObstSymb.Click += new System.EventHandler(this.btnObstSymb_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(16, 668);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 12);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnNetStop);
            this.groupBox1.Controls.Add(this.btnNetStart);
            this.groupBox1.Controls.Add(this.radGnd);
            this.groupBox1.Controls.Add(this.radTwr);
            this.groupBox1.Location = new System.Drawing.Point(400, 688);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(160, 82);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2 stanowiska";
            // 
            // btnNetStop
            // 
            this.btnNetStop.Enabled = false;
            this.btnNetStop.Location = new System.Drawing.Point(83, 49);
            this.btnNetStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnNetStop.Name = "btnNetStop";
            this.btnNetStop.Size = new System.Drawing.Size(65, 28);
            this.btnNetStop.TabIndex = 3;
            this.btnNetStop.Text = "Stop";
            this.btnNetStop.UseVisualStyleBackColor = true;
            this.btnNetStop.Click += new System.EventHandler(this.btnNetStop_Click);
            // 
            // btnNetStart
            // 
            this.btnNetStart.Location = new System.Drawing.Point(83, 21);
            this.btnNetStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnNetStart.Name = "btnNetStart";
            this.btnNetStart.Size = new System.Drawing.Size(65, 28);
            this.btnNetStart.TabIndex = 2;
            this.btnNetStart.Text = "Start";
            this.btnNetStart.UseVisualStyleBackColor = true;
            this.btnNetStart.Click += new System.EventHandler(this.btnNetStart_Click);
            // 
            // radGnd
            // 
            this.radGnd.AutoSize = true;
            this.radGnd.Location = new System.Drawing.Point(9, 53);
            this.radGnd.Margin = new System.Windows.Forms.Padding(4);
            this.radGnd.Name = "radGnd";
            this.radGnd.Size = new System.Drawing.Size(60, 21);
            this.radGnd.TabIndex = 1;
            this.radGnd.TabStop = true;
            this.radGnd.Text = "GND";
            this.radGnd.UseVisualStyleBackColor = true;
            // 
            // radTwr
            // 
            this.radTwr.AutoSize = true;
            this.radTwr.Location = new System.Drawing.Point(9, 25);
            this.radTwr.Margin = new System.Windows.Forms.Padding(4);
            this.radTwr.Name = "radTwr";
            this.radTwr.Size = new System.Drawing.Size(61, 21);
            this.radTwr.TabIndex = 0;
            this.radTwr.TabStop = true;
            this.radTwr.Text = "TWR";
            this.radTwr.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 688);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(375, 148);
            this.listBox1.TabIndex = 25;
            // 
            // btnTwrGnd
            // 
            this.btnTwrGnd.AllowDrop = true;
            this.btnTwrGnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTwrGnd.Location = new System.Drawing.Point(1323, 480);
            this.btnTwrGnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTwrGnd.Name = "btnTwrGnd";
            this.btnTwrGnd.Size = new System.Drawing.Size(116, 84);
            this.btnTwrGnd.TabIndex = 26;
            this.btnTwrGnd.Text = "TWR";
            this.btnTwrGnd.UseVisualStyleBackColor = true;
            this.btnTwrGnd.Visible = false;
            this.btnTwrGnd.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnTwrGnd_DragDrop);
            this.btnTwrGnd.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnTwrGnd_DragEnter);
            // 
            // Bay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1451, 1008);
            this.Controls.Add(this.btnTwrGnd);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnObstSymb);
            this.Controls.Add(this.btnLocalEFS);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btnPdg);
            this.Controls.Add(this.beforeTaxiBay);
            this.Controls.Add(this.pnlTaxiSeparator);
            this.Controls.Add(this.pnlAirborneSeparator);
            this.Controls.Add(this.pnlRunwaySeparator);
            this.Controls.Add(this.airborneBay);
            this.Controls.Add(this.pnlCzas);
            this.Controls.Add(this.bin);
            this.Controls.Add(this.rwyBay);
            this.Controls.Add(this.taxiBay);
            this.Controls.Add(this.pendingDepBay);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Bay";
            this.Text = "EFS";
            this.Load += new System.EventHandler(this.Bay_Load);
            this.pnlRunwaySeparator.ResumeLayout(false);
            this.pnlRunwaySeparator.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCzas.ResumeLayout(false);
            this.pnlCzas.PerformLayout();
            this.pnlAirborneSeparator.ResumeLayout(false);
            this.pnlAirborneSeparator.PerformLayout();
            this.pnlTaxiSeparator.ResumeLayout(false);
            this.pnlTaxiSeparator.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pendingDepBay;
        private System.Windows.Forms.FlowLayoutPanel taxiBay;
        private System.Windows.Forms.FlowLayoutPanel rwyBay;
        private System.Windows.Forms.Panel pnlRunwaySeparator;
        private System.Windows.Forms.Button bin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPasekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjdźToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlCzas;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblCzas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlAirborneSeparator;
        private System.Windows.Forms.Label lblRunwaySeparator;
        private System.Windows.Forms.Label lblAirborneSeparator;
        private System.Windows.Forms.Panel pnlTaxiSeparator;
        private System.Windows.Forms.Label lblTaxiSeparator;
        private System.Windows.Forms.FlowLayoutPanel beforeTaxiBay;
        private System.Windows.Forms.ToolStripMenuItem konfiguracjaRwyToolStripMenuItem;
        private System.Windows.Forms.Button btnPdg;
        public System.Windows.Forms.FlowLayoutPanel airborneBay;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnLocalEFS;
        private System.Windows.Forms.Button btnObstSymb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNetStart;
        private System.Windows.Forms.RadioButton radGnd;
        private System.Windows.Forms.RadioButton radTwr;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnTwrGnd;
        private System.Windows.Forms.Button btnNetStop;



    }
}

