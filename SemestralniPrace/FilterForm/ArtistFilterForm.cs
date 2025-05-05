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
    public partial class ArtistFilterForm : Form
    {
        public Artist ArtistFilter { set; get; }

        public ArtistFilterForm(Artist artistFilter)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            if (artistFilter != null)
            {
                textBoxName.Text = artistFilter.Name;
                textBoxSurname.Text = artistFilter.Surname;

                if (artistFilter.BirthDate != DateTime.MinValue)
                {
                    checkBoxFilterBirth.Checked = true;
                    birthDatePicker.Enabled = true;
                    birthDatePicker.Value = artistFilter.BirthDate;
                }

                if (artistFilter.DeathDate != null)
                {
                    checkBoxFilterDeath.Checked = true;
                    deathDatePicker.Enabled = true;
                    deathDatePicker.Value = artistFilter.DeathDate.Value.Date;
                }

                textBoxDescription.Text = artistFilter.Description;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArtistFilter = new Artist
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Description = textBoxDescription.Text,
            };
            if (checkBoxFilterBirth.Checked) ArtistFilter.BirthDate = birthDatePicker.Value;
            if (checkBoxFilterDeath.Checked) ArtistFilter.DeathDate = deathDatePicker.Value;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxFilterBirth_CheckedChanged(object sender, EventArgs e)
        {
            birthDatePicker.Enabled = checkBoxFilterBirth.Checked;
        }

        private void checkBoxFilterDeath_CheckedChanged(object sender, EventArgs e)
        {
            deathDatePicker.Enabled = checkBoxFilterDeath.Checked;
        }
    }
}
