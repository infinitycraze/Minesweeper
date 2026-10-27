namespace Minesweeper
{
    partial class MinesweeperGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperGame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WidthTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.heightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeightTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LowMineDensityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumMineDensityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HighMineDensityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customDensityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MineDensityTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ShowActionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.MinePanel = new System.Windows.Forms.Panel();
            this.ActionHistoryLabel = new System.Windows.Forms.Label();
            this.MineCounterHundreds = new System.Windows.Forms.PictureBox();
            this.Smiley = new System.Windows.Forms.PictureBox();
            this.MineCounterTens = new System.Windows.Forms.PictureBox();
            this.MineCounterOnes = new System.Windows.Forms.PictureBox();
            this.TimerOnes = new System.Windows.Forms.PictureBox();
            this.TimerTens = new System.Windows.Forms.PictureBox();
            this.TimerHundreds = new System.Windows.Forms.PictureBox();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterHundreds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterTens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterOnes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerOnes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerTens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerHundreds)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minesToolStripMenuItem,
            this.minesToolStripMenuItem1,
            this.ShowActionHistoryToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // minesToolStripMenuItem
            // 
            this.minesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.largeToolStripMenuItem,
            this.toolStripSeparator2,
            this.customSizeMenuItem});
            this.minesToolStripMenuItem.Name = "minesToolStripMenuItem";
            this.minesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.minesToolStripMenuItem.Text = "Size";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.largeToolStripMenuItem.Text = "Large";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // customSizeMenuItem
            // 
            this.customSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widthToolStripMenuItem,
            this.WidthTextbox,
            this.heightToolStripMenuItem,
            this.HeightTextbox,
            this.toolStripSeparator1,
            this.setToolStripMenuItem});
            this.customSizeMenuItem.Name = "customSizeMenuItem";
            this.customSizeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customSizeMenuItem.Text = "Custom...";
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.widthToolStripMenuItem.Enabled = false;
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.widthToolStripMenuItem.Text = "Width:";
            // 
            // WidthTextbox
            // 
            this.WidthTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.WidthTextbox.Name = "WidthTextbox";
            this.WidthTextbox.Size = new System.Drawing.Size(100, 23);
            this.WidthTextbox.Text = "9";
            // 
            // heightToolStripMenuItem
            // 
            this.heightToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.heightToolStripMenuItem.Enabled = false;
            this.heightToolStripMenuItem.Name = "heightToolStripMenuItem";
            this.heightToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.heightToolStripMenuItem.Text = "Height:";
            // 
            // HeightTextbox
            // 
            this.HeightTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HeightTextbox.Name = "HeightTextbox";
            this.HeightTextbox.Size = new System.Drawing.Size(100, 23);
            this.HeightTextbox.Text = "9";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.setToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setToolStripMenuItem.Text = "Set";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
            // 
            // minesToolStripMenuItem1
            // 
            this.minesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LowMineDensityMenuItem,
            this.MediumMineDensityMenuItem,
            this.HighMineDensityMenuItem,
            this.customDensityMenuItem,
            this.MineDensityTextBox});
            this.minesToolStripMenuItem1.Name = "minesToolStripMenuItem1";
            this.minesToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.minesToolStripMenuItem1.Text = "Mine Density";
            // 
            // LowMineDensityMenuItem
            // 
            this.LowMineDensityMenuItem.Name = "LowMineDensityMenuItem";
            this.LowMineDensityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LowMineDensityMenuItem.Text = "12%";
            this.LowMineDensityMenuItem.Click += new System.EventHandler(this.LowMineDensityMenuItem_Click);
            // 
            // MediumMineDensityMenuItem
            // 
            this.MediumMineDensityMenuItem.Name = "MediumMineDensityMenuItem";
            this.MediumMineDensityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MediumMineDensityMenuItem.Text = "15%";
            this.MediumMineDensityMenuItem.Click += new System.EventHandler(this.MediumMineDensityMenuItem_Click);
            // 
            // HighMineDensityMenuItem
            // 
            this.HighMineDensityMenuItem.Name = "HighMineDensityMenuItem";
            this.HighMineDensityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HighMineDensityMenuItem.Text = "20%";
            this.HighMineDensityMenuItem.Click += new System.EventHandler(this.HighMineDensityMenuItem_Click);
            // 
            // customDensityMenuItem
            // 
            this.customDensityMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customDensityMenuItem.Enabled = false;
            this.customDensityMenuItem.Name = "customDensityMenuItem";
            this.customDensityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customDensityMenuItem.Text = "Custom:";
            // 
            // MineDensityTextBox
            // 
            this.MineDensityTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MineDensityTextBox.Name = "MineDensityTextBox";
            this.MineDensityTextBox.Size = new System.Drawing.Size(100, 23);
            this.MineDensityTextBox.ToolTipText = "Set the percentage of mines on the board.\r\nPress Enter to set.";
            this.MineDensityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MineDensityTextBox_KeyDown);
            // 
            // ShowActionHistoryToolStripMenuItem
            // 
            this.ShowActionHistoryToolStripMenuItem.Name = "ShowActionHistoryToolStripMenuItem";
            this.ShowActionHistoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ShowActionHistoryToolStripMenuItem.Text = "Show Action History";
            this.ShowActionHistoryToolStripMenuItem.ToolTipText = "Displays the board\'s coordinates of the most recent moves made.";
            this.ShowActionHistoryToolStripMenuItem.Click += new System.EventHandler(this.ShowActionHistoryToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MinePanel
            // 
            this.MinePanel.AutoSize = true;
            this.MinePanel.Location = new System.Drawing.Point(10, 100);
            this.MinePanel.Name = "MinePanel";
            this.MinePanel.Size = new System.Drawing.Size(10, 10);
            this.MinePanel.TabIndex = 5;
            // 
            // ActionHistoryLabel
            // 
            this.ActionHistoryLabel.AutoEllipsis = true;
            this.ActionHistoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionHistoryLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionHistoryLabel.Location = new System.Drawing.Point(12, 413);
            this.ActionHistoryLabel.Name = "ActionHistoryLabel";
            this.ActionHistoryLabel.Size = new System.Drawing.Size(456, 30);
            this.ActionHistoryLabel.TabIndex = 6;
            this.ActionHistoryLabel.Visible = false;
            // 
            // MineCounterHundreds
            // 
            this.MineCounterHundreds.Image = ((System.Drawing.Image)(resources.GetObject("MineCounterHundreds.Image")));
            this.MineCounterHundreds.Location = new System.Drawing.Point(20, 35);
            this.MineCounterHundreds.Name = "MineCounterHundreds";
            this.MineCounterHundreds.Size = new System.Drawing.Size(26, 46);
            this.MineCounterHundreds.TabIndex = 7;
            this.MineCounterHundreds.TabStop = false;
            // 
            // Smiley
            // 
            this.Smiley.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Smiley.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Smiley.Cursor = System.Windows.Forms.Cursors.Default;
            this.Smiley.Image = global::Minesweeper.Properties.Resources.smiley;
            this.Smiley.Location = new System.Drawing.Point(210, 28);
            this.Smiley.Name = "Smiley";
            this.Smiley.Size = new System.Drawing.Size(60, 60);
            this.Smiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Smiley.TabIndex = 4;
            this.Smiley.TabStop = false;
            this.Smiley.WaitOnLoad = true;
            this.Smiley.Click += new System.EventHandler(this.Smiley_Click);
            this.Smiley.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Smiley_MouseDown);
            this.Smiley.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Smiley_MouseUp);
            // 
            // MineCounterTens
            // 
            this.MineCounterTens.Image = ((System.Drawing.Image)(resources.GetObject("MineCounterTens.Image")));
            this.MineCounterTens.Location = new System.Drawing.Point(46, 35);
            this.MineCounterTens.Name = "MineCounterTens";
            this.MineCounterTens.Size = new System.Drawing.Size(26, 46);
            this.MineCounterTens.TabIndex = 8;
            this.MineCounterTens.TabStop = false;
            // 
            // MineCounterOnes
            // 
            this.MineCounterOnes.Image = ((System.Drawing.Image)(resources.GetObject("MineCounterOnes.Image")));
            this.MineCounterOnes.Location = new System.Drawing.Point(72, 35);
            this.MineCounterOnes.Name = "MineCounterOnes";
            this.MineCounterOnes.Size = new System.Drawing.Size(26, 46);
            this.MineCounterOnes.TabIndex = 9;
            this.MineCounterOnes.TabStop = false;
            // 
            // TimerOnes
            // 
            this.TimerOnes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerOnes.Image = ((System.Drawing.Image)(resources.GetObject("TimerOnes.Image")));
            this.TimerOnes.Location = new System.Drawing.Point(434, 35);
            this.TimerOnes.Name = "TimerOnes";
            this.TimerOnes.Size = new System.Drawing.Size(26, 46);
            this.TimerOnes.TabIndex = 12;
            this.TimerOnes.TabStop = false;
            // 
            // TimerTens
            // 
            this.TimerTens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerTens.Image = ((System.Drawing.Image)(resources.GetObject("TimerTens.Image")));
            this.TimerTens.Location = new System.Drawing.Point(408, 35);
            this.TimerTens.Name = "TimerTens";
            this.TimerTens.Size = new System.Drawing.Size(26, 46);
            this.TimerTens.TabIndex = 11;
            this.TimerTens.TabStop = false;
            // 
            // TimerHundreds
            // 
            this.TimerHundreds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerHundreds.Image = ((System.Drawing.Image)(resources.GetObject("TimerHundreds.Image")));
            this.TimerHundreds.Location = new System.Drawing.Point(382, 35);
            this.TimerHundreds.Name = "TimerHundreds";
            this.TimerHundreds.Size = new System.Drawing.Size(26, 46);
            this.TimerHundreds.TabIndex = 10;
            this.TimerHundreds.TabStop = false;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MenuPanel.Location = new System.Drawing.Point(12, 25);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(456, 67);
            this.MenuPanel.TabIndex = 13;
            // 
            // MinesweeperGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 457);
            this.Controls.Add(this.TimerOnes);
            this.Controls.Add(this.TimerTens);
            this.Controls.Add(this.TimerHundreds);
            this.Controls.Add(this.MineCounterOnes);
            this.Controls.Add(this.MineCounterTens);
            this.Controls.Add(this.MineCounterHundreds);
            this.Controls.Add(this.ActionHistoryLabel);
            this.Controls.Add(this.MinePanel);
            this.Controls.Add(this.Smiley);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MenuPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MinesweeperGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterHundreds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterTens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineCounterOnes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerOnes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerTens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerHundreds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minesToolStripMenuItem1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox Smiley;
        private System.Windows.Forms.Panel MinePanel;
        private System.Windows.Forms.Label ActionHistoryLabel;
        private System.Windows.Forms.ToolStripMenuItem ShowActionHistoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox MineCounterHundreds;
        private System.Windows.Forms.PictureBox MineCounterTens;
        private System.Windows.Forms.PictureBox MineCounterOnes;
        private System.Windows.Forms.PictureBox TimerOnes;
        private System.Windows.Forms.PictureBox TimerTens;
        private System.Windows.Forms.PictureBox TimerHundreds;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customSizeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LowMineDensityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediumMineDensityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HighMineDensityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customDensityMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox WidthTextbox;
        private System.Windows.Forms.ToolStripMenuItem heightToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox HeightTextbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox MineDensityTextBox;
    }
}

