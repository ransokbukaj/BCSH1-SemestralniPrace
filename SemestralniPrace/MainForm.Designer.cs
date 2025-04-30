namespace SemestralniPrace
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            contentPanel = new Panel();
            leftMenuStrip = new MenuStrip();
            artistsMenuItem = new ToolStripMenuItem();
            artworksMenuItem = new ToolStripMenuItem();
            artExhibitsMenuItem = new ToolStripMenuItem();
            substratesMenuItem = new ToolStripMenuItem();
            techniquesMenuItem = new ToolStripMenuItem();
            stylesMenuItem = new ToolStripMenuItem();
            leftMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contentPanel
            // 
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(104, 0);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(678, 453);
            contentPanel.TabIndex = 1;
            // 
            // leftMenuStrip
            // 
            leftMenuStrip.Dock = DockStyle.Left;
            leftMenuStrip.ImageScalingSize = new Size(20, 20);
            leftMenuStrip.Items.AddRange(new ToolStripItem[] { artistsMenuItem, artworksMenuItem, artExhibitsMenuItem, substratesMenuItem, techniquesMenuItem, stylesMenuItem });
            leftMenuStrip.Location = new Point(0, 0);
            leftMenuStrip.Name = "leftMenuStrip";
            leftMenuStrip.Size = new Size(104, 453);
            leftMenuStrip.TabIndex = 2;
            leftMenuStrip.Text = "menuStrip1";
            // 
            // artistsMenuItem
            // 
            artistsMenuItem.Name = "artistsMenuItem";
            artistsMenuItem.Size = new Size(91, 24);
            artistsMenuItem.Text = "Artists";
            artistsMenuItem.Click += artistsMenuItem_Click;
            // 
            // artworksMenuItem
            // 
            artworksMenuItem.Name = "artworksMenuItem";
            artworksMenuItem.Size = new Size(91, 24);
            artworksMenuItem.Text = "Artworks";
            artworksMenuItem.Click += artworksMenuItem_Click;
            // 
            // artExhibitsMenuItem
            // 
            artExhibitsMenuItem.Name = "artExhibitsMenuItem";
            artExhibitsMenuItem.Size = new Size(91, 24);
            artExhibitsMenuItem.Text = "Art Exhibits";
            artExhibitsMenuItem.Click += artExhibitsMenuItem_Click;
            // 
            // substratesMenuItem
            // 
            substratesMenuItem.Name = "substratesMenuItem";
            substratesMenuItem.Size = new Size(91, 24);
            substratesMenuItem.Text = "Substrates";
            substratesMenuItem.Click += substratesMenuItem_Click;
            // 
            // techniquesMenuItem
            // 
            techniquesMenuItem.Name = "techniquesMenuItem";
            techniquesMenuItem.Size = new Size(91, 24);
            techniquesMenuItem.Text = "Techniques";
            techniquesMenuItem.Click += techniquesMenuItem_Click;
            // 
            // stylesMenuItem
            // 
            stylesMenuItem.Name = "stylesMenuItem";
            stylesMenuItem.Size = new Size(91, 24);
            stylesMenuItem.Text = "Styles";
            stylesMenuItem.Click += stylesMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(contentPanel);
            Controls.Add(leftMenuStrip);
            MainMenuStrip = leftMenuStrip;
            Name = "MainForm";
            Text = "Art Gallery Management";
            leftMenuStrip.ResumeLayout(false);
            leftMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel contentPanel;
        private MenuStrip leftMenuStrip;
        private ToolStripMenuItem artistsMenuItem;
        private ToolStripMenuItem artworksMenuItem;
        private ToolStripMenuItem artExhibitsMenuItem;
        private ToolStripMenuItem substratesMenuItem;
        private ToolStripMenuItem techniquesMenuItem;
        private ToolStripMenuItem stylesMenuItem;
    }
}
