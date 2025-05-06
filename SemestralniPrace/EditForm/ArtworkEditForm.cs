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

namespace SemestralniPrace.EditForm
{
    public partial class ArtworkEditForm : Form
    {
        private StyleRepository styleRepository;
        private SubstrateRepository substrateRepository;
        private TechniqueRepository techniqueRepository;
        private ArtistRepository artistRepository;
        private ArtExhibitRepository artExhibitRepository;

        public Artwork Artwork;

        public ArtworkEditForm(Artwork artwork)
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

            Artwork = artwork;

            if (Artwork != null && Artwork.Id != 0)
            {
                Text = "Edit Artwork";
                textBoxName.Text = Artwork.Name;
                textBoxDescription.Text = Artwork.Description;
                numericWidth.Value = Artwork.Width;
                numericHeight.Value = Artwork.Height;
                datePublishedPicker.Value = Artwork.DatePublished;
                comboBoxStyle.SelectedValue = Artwork.Style.Id;
                comboBoxSubstrate.SelectedValue = Artwork.Substrate.Id;
                comboBoxTechnique.SelectedValue = Artwork.Technique.Id;
                comboBoxArtist.SelectedValue = Artwork.Artist.Id;
                if (Artwork.ArtExhibit != null) comboBoxArtExhibit.SelectedValue = Artwork.ArtExhibit.Id;
            }

            textBoxName.TextChanged += (s, e) => UpdateOkButtonState();
            comboBoxStyle.SelectedIndexChanged += (s, e) => UpdateOkButtonState();
            comboBoxSubstrate.SelectedIndexChanged += (s, e) => UpdateOkButtonState();
            comboBoxTechnique.SelectedIndexChanged += (s, e) => UpdateOkButtonState();
            comboBoxArtist.SelectedIndexChanged += (s, e) => UpdateOkButtonState();

            UpdateOkButtonState();
        }

        private void UpdateOkButtonState()
        {
            bool hasName = !string.IsNullOrWhiteSpace(textBoxName.Text);
            bool hasStyle = comboBoxStyle.SelectedIndex != 0;
            bool hasSubstrate = comboBoxSubstrate.SelectedIndex != 0;
            bool hasTechnique = comboBoxTechnique.SelectedIndex != 0;
            bool hasArtist = comboBoxArtist.SelectedIndex != 0;

            btnOk.Enabled = hasName && hasStyle && hasSubstrate && hasTechnique && hasArtist;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Artwork = new Artwork
            {
                Id = Artwork?.Id ?? 0,
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                Width = (int)numericWidth.Value,
                Height = (int)numericHeight.Value,
                DatePublished = datePublishedPicker.Value,
                Style = new BaseModel { Id = (int)comboBoxStyle.SelectedValue },
                Substrate = new BaseModel { Id = (int)comboBoxSubstrate.SelectedValue },
                Technique = new BaseModel { Id = (int)comboBoxTechnique.SelectedValue },
                Artist = new Artist { Id = (int)comboBoxArtist.SelectedValue },
            };
            if (comboBoxArtExhibit.SelectedValue != null) Artwork.ArtExhibit = new ArtExhibit { Id = (int)comboBoxArtExhibit.SelectedValue };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
