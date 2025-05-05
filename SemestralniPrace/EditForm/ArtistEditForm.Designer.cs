namespace SemestralniPrace.EditForm
{
    partial class ArtistEditForm
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
            textBoxSurname = new TextBox();
            birthDatePicker = new DateTimePicker();
            deathDatePicker = new DateTimePicker();
            textBoxDescription = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            checkBoxHasDied = new CheckBox();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(120, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(120, 45);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(250, 27);
            textBoxSurname.TabIndex = 1;
            // 
            // birthDatePicker
            // 
            birthDatePicker.Location = new Point(120, 78);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(250, 27);
            birthDatePicker.TabIndex = 2;
            // 
            // deathDatePicker
            // 
            deathDatePicker.Enabled = false;
            deathDatePicker.Location = new Point(120, 111);
            deathDatePicker.Name = "deathDatePicker";
            deathDatePicker.Size = new Size(250, 27);
            deathDatePicker.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(120, 174);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(250, 27);
            textBoxDescription.TabIndex = 4;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(176, 207);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(276, 207);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 8;
            label2.Text = "Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 9;
            label3.Text = "Birth Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 111);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 10;
            label4.Text = "Death Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 174);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 11;
            label5.Text = "Description";
            // 
            // checkBoxHasDied
            // 
            checkBoxHasDied.AutoSize = true;
            checkBoxHasDied.Location = new Point(120, 144);
            checkBoxHasDied.Name = "checkBoxHasDied";
            checkBoxHasDied.Size = new Size(92, 24);
            checkBoxHasDied.TabIndex = 12;
            checkBoxHasDied.Text = "Has Died";
            checkBoxHasDied.UseVisualStyleBackColor = true;
            checkBoxHasDied.CheckedChanged += checkBoxHasDied_CheckedChanged;
            // 
            // ArtistEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 243);
            Controls.Add(checkBoxHasDied);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(textBoxDescription);
            Controls.Add(deathDatePicker);
            Controls.Add(birthDatePicker);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ArtistEditForm";
            ShowIcon = false;
            Text = "Add Artist";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private DateTimePicker birthDatePicker;
        private DateTimePicker deathDatePicker;
        private TextBox textBoxDescription;
        private Button btnOk;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox checkBoxHasDied;
    }
}