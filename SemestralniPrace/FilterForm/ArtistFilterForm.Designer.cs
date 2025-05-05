namespace SemestralniPrace.FilterForm
{
    partial class ArtistFilterForm
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
            checkBoxFilterBirth = new CheckBox();
            deathDatePicker = new DateTimePicker();
            checkBoxFilterDeath = new CheckBox();
            textBoxDescription = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            birthDatePicker.Enabled = false;
            birthDatePicker.Location = new Point(120, 78);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(250, 27);
            birthDatePicker.TabIndex = 2;
            // 
            // checkBoxFilterBirth
            // 
            checkBoxFilterBirth.AutoSize = true;
            checkBoxFilterBirth.Location = new Point(120, 111);
            checkBoxFilterBirth.Name = "checkBoxFilterBirth";
            checkBoxFilterBirth.Size = new Size(135, 24);
            checkBoxFilterBirth.TabIndex = 3;
            checkBoxFilterBirth.Text = "Filter Birth Date";
            checkBoxFilterBirth.UseVisualStyleBackColor = true;
            checkBoxFilterBirth.CheckedChanged += checkBoxFilterBirth_CheckedChanged;
            // 
            // deathDatePicker
            // 
            deathDatePicker.Enabled = false;
            deathDatePicker.Location = new Point(120, 141);
            deathDatePicker.Name = "deathDatePicker";
            deathDatePicker.Size = new Size(250, 27);
            deathDatePicker.TabIndex = 4;
            // 
            // checkBoxFilterDeath
            // 
            checkBoxFilterDeath.AutoSize = true;
            checkBoxFilterDeath.Location = new Point(120, 174);
            checkBoxFilterDeath.Name = "checkBoxFilterDeath";
            checkBoxFilterDeath.Size = new Size(144, 24);
            checkBoxFilterDeath.TabIndex = 5;
            checkBoxFilterDeath.Text = "Filter Death Date";
            checkBoxFilterDeath.UseVisualStyleBackColor = true;
            checkBoxFilterDeath.CheckedChanged += checkBoxFilterDeath_CheckedChanged;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(120, 204);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(250, 27);
            textBoxDescription.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(276, 237);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(176, 237);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 8;
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
            label1.TabIndex = 9;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 10;
            label2.Text = "Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 11;
            label3.Text = "Birth Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 12;
            label4.Text = "Death Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 204);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 13;
            label5.Text = "Description";
            // 
            // ArtistFilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 273);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(textBoxDescription);
            Controls.Add(checkBoxFilterDeath);
            Controls.Add(deathDatePicker);
            Controls.Add(checkBoxFilterBirth);
            Controls.Add(birthDatePicker);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ArtistFilterForm";
            ShowIcon = false;
            Text = "Filter Artists";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private DateTimePicker birthDatePicker;
        private CheckBox checkBoxFilterBirth;
        private DateTimePicker deathDatePicker;
        private CheckBox checkBoxFilterDeath;
        private TextBox textBoxDescription;
        private Button btnCancel;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}