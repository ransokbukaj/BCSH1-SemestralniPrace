namespace SemestralniPrace.EditForm
{
    partial class ArtExhibitEditForm
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
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            checkBoxHasEndDate = new CheckBox();
            btnCancel = new Button();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(120, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(120, 45);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(250, 27);
            textBoxDescription.TabIndex = 1;
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(120, 78);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(250, 27);
            startDatePicker.TabIndex = 2;
            // 
            // endDatePicker
            // 
            endDatePicker.Enabled = false;
            endDatePicker.Location = new Point(120, 111);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(250, 27);
            endDatePicker.TabIndex = 3;
            // 
            // checkBoxHasEndDate
            // 
            checkBoxHasEndDate.AutoSize = true;
            checkBoxHasEndDate.Location = new Point(120, 144);
            checkBoxHasEndDate.Name = "checkBoxHasEndDate";
            checkBoxHasEndDate.Size = new Size(121, 24);
            checkBoxHasEndDate.TabIndex = 4;
            checkBoxHasEndDate.Text = "Has End Date";
            checkBoxHasEndDate.UseVisualStyleBackColor = true;
            checkBoxHasEndDate.CheckedChanged += checkBoxHasEndDate_CheckedChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(276, 174);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(176, 174);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 6;
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
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 8;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 9;
            label3.Text = "Start Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 111);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 10;
            label4.Text = "End Date";
            // 
            // ArtExhibitEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 213);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(checkBoxHasEndDate);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ArtExhibitEditForm";
            ShowIcon = false;
            Text = "Add Art Exhibit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private CheckBox checkBoxHasEndDate;
        private Button btnCancel;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}