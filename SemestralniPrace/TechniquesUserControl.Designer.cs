namespace SemestralniPrace
{
    partial class TechniquesUserControl
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
            bottomMenuStrip = new MenuStrip();
            addMenuItem = new ToolStripMenuItem();
            editMenuItem = new ToolStripMenuItem();
            deleteMenuItem = new ToolStripMenuItem();
            filterMenuItem = new ToolStripMenuItem();
            importCsvMenuItem = new ToolStripMenuItem();
            exportCsvMenuItem = new ToolStripMenuItem();
            listView = new ListView();
            bottomMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // bottomMenuStrip
            // 
            bottomMenuStrip.Dock = DockStyle.Bottom;
            bottomMenuStrip.ImageScalingSize = new Size(20, 20);
            bottomMenuStrip.Items.AddRange(new ToolStripItem[] { addMenuItem, editMenuItem, deleteMenuItem, filterMenuItem, importCsvMenuItem, exportCsvMenuItem });
            bottomMenuStrip.Location = new Point(0, 422);
            bottomMenuStrip.Name = "bottomMenuStrip";
            bottomMenuStrip.Size = new Size(680, 28);
            bottomMenuStrip.TabIndex = 1;
            bottomMenuStrip.Text = "bottomMenuStrip";
            // 
            // addMenuItem
            // 
            addMenuItem.Name = "addMenuItem";
            addMenuItem.Size = new Size(51, 24);
            addMenuItem.Text = "Add";
            addMenuItem.Click += addMenuItem_Click;
            // 
            // editMenuItem
            // 
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(49, 24);
            editMenuItem.Text = "Edit";
            editMenuItem.Click += editMenuItem_Click;
            // 
            // deleteMenuItem
            // 
            deleteMenuItem.Name = "deleteMenuItem";
            deleteMenuItem.Size = new Size(67, 24);
            deleteMenuItem.Text = "Delete";
            deleteMenuItem.Click += deleteMenuItem_Click;
            // 
            // filterMenuItem
            // 
            filterMenuItem.Name = "filterMenuItem";
            filterMenuItem.Size = new Size(56, 24);
            filterMenuItem.Text = "Filter";
            filterMenuItem.Click += filterMenuItem_Click;
            // 
            // importCsvMenuItem
            // 
            importCsvMenuItem.Name = "importCsvMenuItem";
            importCsvMenuItem.Size = new Size(98, 24);
            importCsvMenuItem.Text = "Import CSV";
            importCsvMenuItem.Click += importCsvMenuItem_Click;
            // 
            // exportCsvMenuItem
            // 
            exportCsvMenuItem.Name = "exportCsvMenuItem";
            exportCsvMenuItem.Size = new Size(96, 24);
            exportCsvMenuItem.Text = "Export CSV";
            exportCsvMenuItem.Click += exportCsvMenuItem_Click;
            // 
            // listView
            // 
            listView.Dock = DockStyle.Fill;
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(680, 422);
            listView.TabIndex = 2;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // TechniquesUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView);
            Controls.Add(bottomMenuStrip);
            Name = "TechniquesUserControl";
            Size = new Size(680, 450);
            bottomMenuStrip.ResumeLayout(false);
            bottomMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip bottomMenuStrip;
        private ToolStripMenuItem addMenuItem;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem deleteMenuItem;
        private ToolStripMenuItem filterMenuItem;
        private ToolStripMenuItem importCsvMenuItem;
        private ToolStripMenuItem exportCsvMenuItem;
        private ListView listView;
    }
}
