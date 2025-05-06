using Microsoft.VisualBasic.Devices;
using SemestralniPrace.Model;
using SemestralniPrace.Repository;
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
    public partial class ArtworkFilterForm : Form
    {
        private StyleRepository styleRepository;
        private SubstrateRepository substrateRepository;
        private TechniqueRepository techniqueRepository;
        private ArtistRepository artistRepository;
        private ArtExhibitRepository artExhibitRepository;

        public Artwork ArtworkFilter;

        public ArtworkFilterForm(Artwork artworkFilter)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            styleRepository = new StyleRepository();
            substrateRepository = new SubstrateRepository();
            techniqueRepository = new TechniqueRepository();
            artistRepository = new ArtistRepository();
            artExhibitRepository = new ArtExhibitRepository();

            var styles = new List<BaseModel>();
            styles.Add(new BaseModel());
            styles.AddRange(styleRepository.GetList(null));

            comboBoxStyle.DisplayMember = "Name";
            comboBoxStyle.ValueMember = "Id";
            comboBoxStyle.DataSource = styles;

            var substrates = new List<BaseModel>();
            substrates.Add(new BaseModel());
            substrates.AddRange(substrateRepository.GetList(null));

            comboBoxSubstrate.DisplayMember = "Name";
            comboBoxSubstrate.ValueMember = "Id";
            comboBoxSubstrate.DataSource = substrates;

            var techniques = new List<BaseModel>();
            techniques.Add(new BaseModel());
            techniques.AddRange(techniqueRepository.GetList(null));

            comboBoxTechnique.DisplayMember = "Name";
            comboBoxTechnique.ValueMember = "Id";
            comboBoxTechnique.DataSource = techniques;

            var artists = new List<Artist>();
            artists.Add(new Artist());
            artists.AddRange(artistRepository.GetList(null));

            comboBoxArtist.DisplayMember = "FullName";
            comboBoxArtist.ValueMember = "Id";
            comboBoxArtist.DataSource = artists;

            var artExhibits = new List<ArtExhibit>();
            artExhibits.Add(new ArtExhibit());
            artExhibits.AddRange(artExhibitRepository.GetList(null));

            comboBoxArtExhibit.DisplayMember = "Name";
            comboBoxArtExhibit.ValueMember = "Id";
            comboBoxArtExhibit.DataSource = artExhibits;

            ArtworkFilter = artworkFilter;

            if (ArtworkFilter != null)
            {
                textBoxName.Text = ArtworkFilter.Name;
                textBoxDescription.Text = ArtworkFilter.Description;
                numericWidth.Value = ArtworkFilter.Width;
                numericHeight.Value = ArtworkFilter.Height;

                if (ArtworkFilter.DatePublished != DateTime.MinValue)
                {
                    checkBoxFilterDatePublished.Checked = true;
                    datePublishedPicker.Enabled = true;
                    datePublishedPicker.Value = ArtworkFilter.DatePublished;
                }

                if (ArtworkFilter.Style != null) comboBoxStyle.SelectedValue = ArtworkFilter.Style.Id;
                if (ArtworkFilter.Substrate != null) comboBoxSubstrate.SelectedValue = ArtworkFilter.Substrate.Id;
                if (ArtworkFilter.Technique != null) comboBoxTechnique.SelectedValue = ArtworkFilter.Technique.Id;
                if (ArtworkFilter.Artist != null)  comboBoxArtist.SelectedValue = ArtworkFilter.Artist.Id;
                if (ArtworkFilter.ArtExhibit != null) comboBoxArtExhibit.SelectedValue = ArtworkFilter.ArtExhibit.Id;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArtworkFilter = new Artwork
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                Width = (int)numericWidth.Value,
                Height = (int)numericHeight.Value,                
            };
            if (checkBoxFilterDatePublished.Checked) ArtworkFilter.DatePublished = datePublishedPicker.Value;
            if (comboBoxStyle.SelectedValue != null) ArtworkFilter.Style = new BaseModel { Id = (int)comboBoxStyle.SelectedValue };
            if (comboBoxSubstrate.SelectedValue != null) ArtworkFilter.Substrate = new BaseModel { Id = (int)comboBoxSubstrate.SelectedValue };
            if (comboBoxTechnique.SelectedValue != null) ArtworkFilter.Technique = new BaseModel { Id = (int)comboBoxTechnique.SelectedValue };
            if (comboBoxArtist.SelectedValue != null) ArtworkFilter.Artist = new Artist { Id = (int)comboBoxArtist.SelectedValue };
            if (comboBoxArtExhibit.SelectedValue != null) ArtworkFilter.ArtExhibit = new ArtExhibit { Id = (int)comboBoxArtExhibit.SelectedValue };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void chechBoxFilterDatePublished_CheckedChanged(object sender, EventArgs e)
        {
            datePublishedPicker.Enabled = checkBoxFilterDatePublished.Checked;
        }
    }
}
