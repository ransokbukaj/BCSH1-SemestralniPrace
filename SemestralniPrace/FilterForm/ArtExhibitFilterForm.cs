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

namespace SemestralniPrace.FilterForm
{
    public partial class ArtExhibitFilterForm : Form
    {
        public ArtExhibit ArtExhibitFilter;

        public ArtExhibitFilterForm(ArtExhibit artExhibitFilter)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            if (artExhibitFilter != null)
            {
                textBoxName.Text = artExhibitFilter.Name;
                textBoxDescription.Text = artExhibitFilter.Description;

                if (artExhibitFilter.StartDate != DateTime.MinValue)
                {
                    checkBoxFilterStart.Checked = true;
                    startDatePicker.Enabled = true;
                    startDatePicker.Value = artExhibitFilter.StartDate;
                }

                if (artExhibitFilter.EndDate != null)
                {
                    checkBoxFilterEnd.Checked = true;
                    endDatePicker.Enabled = true;
                    endDatePicker.Value = artExhibitFilter.EndDate.Value.Date;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArtExhibitFilter = new ArtExhibit
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
            };
            if (checkBoxFilterStart.Checked) ArtExhibitFilter.StartDate = startDatePicker.Value;
            if (checkBoxFilterEnd.Checked) ArtExhibitFilter.EndDate = endDatePicker.Value;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxFilterStart_CheckedChanged(object sender, EventArgs e)
        {
            startDatePicker.Enabled = checkBoxFilterStart.Checked;
        }

        private void checkBoxFilterEnd_CheckedChanged(object sender, EventArgs e)
        {
            endDatePicker.Enabled = checkBoxFilterEnd.Checked;
        }
    }
}
