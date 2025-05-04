using SemestralniPrace.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace.EditForm
{
    public partial class ArtistEditForm : Form
    {
        public Artist Artist { set; get; }

        public ArtistEditForm(Artist artist)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            Artist = artist;

            if (Artist != null && Artist.Id != 0)
            {
                Text = "Edit Artist";
                textBoxName.Text = Artist.Name;
                textBoxSurname.Text = Artist.Surname;
                birthDatePicker.Value = Artist.BirthDate;

                if (Artist.DeathDate != null)
                {
                    checkBoxHasDied.Checked = true;
                    deathDatePicker.Enabled = true;
                    deathDatePicker.Value = (DateTime)Artist.DeathDate;
                }

                textBoxDescription.Text = Artist.Description;
            }

            textBoxName.TextChanged += (s, e) => UpdateOkButtonState();
            textBoxSurname.TextChanged += (s, e) => UpdateOkButtonState();

            UpdateOkButtonState();
        }

        private void UpdateOkButtonState()
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxSurname.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Artist = new Artist(Artist?.Id ?? 0, textBoxName.Text, textBoxSurname.Text, birthDatePicker.Value, checkBoxHasDied.Checked ? deathDatePicker.Value : null, textBoxDescription.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxHasDied_CheckedChanged(object sender, EventArgs e)
        {
            deathDatePicker.Enabled = checkBoxHasDied.Checked;
        }
    }
}
