namespace SemestralniPrace.EditForm
{
    partial class ArtworkEditForm
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
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            numericWidth = new NumericUpDown();
            numericHeight = new NumericUpDown();
            datePublishedPicker = new DateTimePicker();
            comboBoxStyle = new ComboBox();
            comboBoxSubstrate = new ComboBox();
            comboBoxTechnique = new ComboBox();
            comboBoxArtist = new ComboBox();
            comboBoxArtExhibit = new ComboBox();
            btnCancel = new Button();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(130, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(130, 45);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(250, 27);
            textBoxDescription.TabIndex = 1;
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(130, 78);
            numericWidth.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(250, 27);
            numericWidth.TabIndex = 2;
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(130, 111);
            numericHeight.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(250, 27);
            numericHeight.TabIndex = 3;
            // 
            // datePublishedPicker
            // 
            datePublishedPicker.Location = new Point(130, 144);
            datePublishedPicker.Name = "datePublishedPicker";
            datePublishedPicker.Size = new Size(250, 27);
            datePublishedPicker.TabIndex = 4;
            // 
            // comboBoxStyle
            // 
            comboBoxStyle.FormattingEnabled = true;
            comboBoxStyle.Location = new Point(130, 177);
            comboBoxStyle.Name = "comboBoxStyle";
            comboBoxStyle.Size = new Size(250, 28);
            comboBoxStyle.TabIndex = 5;
            // 
            // comboBoxSubstrate
            // 
            comboBoxSubstrate.FormattingEnabled = true;
            comboBoxSubstrate.Location = new Point(130, 211);
            comboBoxSubstrate.Name = "comboBoxSubstrate";
            comboBoxSubstrate.Size = new Size(250, 28);
            comboBoxSubstrate.TabIndex = 6;
            // 
            // comboBoxTechnique
            // 
            comboBoxTechnique.FormattingEnabled = true;
            comboBoxTechnique.Location = new Point(130, 245);
            comboBoxTechnique.Name = "comboBoxTechnique";
            comboBoxTechnique.Size = new Size(250, 28);
            comboBoxTechnique.TabIndex = 7;
            // 
            // comboBoxArtist
            // 
            comboBoxArtist.FormattingEnabled = true;
            comboBoxArtist.Location = new Point(130, 279);
            comboBoxArtist.Name = "comboBoxArtist";
            comboBoxArtist.Size = new Size(250, 28);
            comboBoxArtist.TabIndex = 8;
            // 
            // comboBoxArtExhibit
            // 
            comboBoxArtExhibit.FormattingEnabled = true;
            comboBoxArtExhibit.Location = new Point(130, 313);
            comboBoxArtExhibit.Name = "comboBoxArtExhibit";
            comboBoxArtExhibit.Size = new Size(250, 28);
            comboBoxArtExhibit.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(286, 347);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(186, 347);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 12;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 13;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 14;
            label3.Text = "Width";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 111);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 15;
            label4.Text = "Height";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 144);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 16;
            label5.Text = "Date Published";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 177);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 17;
            label6.Text = "Style";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 211);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 18;
            label7.Text = "Substrate";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 245);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 19;
            label8.Text = "Technique";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 279);
            label9.Name = "label9";
            label9.Size = new Size(44, 20);
            label9.TabIndex = 20;
            label9.Text = "Artist";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 313);
            label10.Name = "label10";
            label10.Size = new Size(78, 20);
            label10.TabIndex = 21;
            label10.Text = "Art Exhibit";
            // 
            // ArtworkEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 383);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(comboBoxArtExhibit);
            Controls.Add(comboBoxArtist);
            Controls.Add(comboBoxTechnique);
            Controls.Add(comboBoxSubstrate);
            Controls.Add(comboBoxStyle);
            Controls.Add(datePublishedPicker);
            Controls.Add(numericHeight);
            Controls.Add(numericWidth);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ArtworkEditForm";
            ShowIcon = false;
            Text = "Add Artwork";
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private NumericUpDown numericWidth;
        private NumericUpDown numericHeight;
        private DateTimePicker datePublishedPicker;
        private ComboBox comboBoxStyle;
        private ComboBox comboBoxSubstrate;
        private ComboBox comboBoxTechnique;
        private ComboBox comboBoxArtist;
        private ComboBox comboBoxArtExhibit;
        private Button btnCancel;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}