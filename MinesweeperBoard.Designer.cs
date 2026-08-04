namespace Minesweeper
{
    partial class MinesweeperBoard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.MinePanel = new System.Windows.Forms.Panel();
            this.Smiley = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minesToolStripMenuItem,
            this.minesToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // minesToolStripMenuItem
            // 
            this.minesToolStripMenuItem.Name = "minesToolStripMenuItem";
            this.minesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.minesToolStripMenuItem.Text = "Dimensions";
            this.minesToolStripMenuItem.Click += new System.EventHandler(this.DimensionsToolStripMenuItem_Click);
            // 
            // minesToolStripMenuItem1
            // 
            this.minesToolStripMenuItem1.Name = "minesToolStripMenuItem1";
            this.minesToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.minesToolStripMenuItem1.Text = "Mines";
            this.minesToolStripMenuItem1.Click += new System.EventHandler(this.MinesToolStripMenuItem_Click);
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
            this.MinePanel.Location = new System.Drawing.Point(12, 103);
            this.MinePanel.Name = "MinePanel";
            this.MinePanel.Size = new System.Drawing.Size(885, 571);
            this.MinePanel.TabIndex = 5;
            // 
            // Smiley
            // 
            this.Smiley.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Smiley.Cursor = System.Windows.Forms.Cursors.Default;
            this.Smiley.Image = global::Minesweeper.Properties.Resources.smiley;
            this.Smiley.Location = new System.Drawing.Point(427, 40);
            this.Smiley.Name = "Smiley";
            this.Smiley.Size = new System.Drawing.Size(56, 57);
            this.Smiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Smiley.TabIndex = 4;
            this.Smiley.TabStop = false;
            this.Smiley.WaitOnLoad = true;
            this.Smiley.Click += new System.EventHandler(this.Smiley_Click);
            // 
            // MinesweeperBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 686);
            this.Controls.Add(this.MinePanel);
            this.Controls.Add(this.Smiley);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MinesweeperBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Smiley)).EndInit();
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
    }
}

