using SemestralniPrace.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace.EditForm
{
    public partial class ArtExhibitEditForm : Form
    {
        public ArtExhibit ArtExhibit;

        public ArtExhibitEditForm(ArtExhibit artExhibit)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            ArtExhibit = artExhibit;

            if (ArtExhibit != null && ArtExhibit.Id != 0)
            {
                Text = "Edit Art Exhibit";
                textBoxName.Text = ArtExhibit.Name;
                textBoxDescription.Text = ArtExhibit.Description;
                startDatePicker.Value = ArtExhibit.StartDate;

                if (ArtExhibit.EndDate != null)
                {
                    checkBoxHasEndDate.Checked = true;
                    endDatePicker.Enabled = true;
                    endDatePicker.Value = ArtExhibit.EndDate.Value.Date;
                }                
            }

            textBoxName.TextChanged += (s, e) => UpdateOkButtonState();

            UpdateOkButtonState();
        }

        private void UpdateOkButtonState()
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(textBoxName.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArtExhibit = new ArtExhibit(ArtExhibit?.Id ?? 0, textBoxName.Text, textBoxDescription.Text, startDatePicker.Value, checkBoxHasEndDate.Checked ? endDatePicker.Value : null);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxHasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            endDatePicker.Enabled = checkBoxHasEndDate.Checked;
        }
    }
}
