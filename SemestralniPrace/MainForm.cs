namespace SemestralniPrace
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadUserControl(new ArtExhibitsUserControl());
        }

        private void LoadUserControl(UserControl userControl)
        {
            contentPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(userControl);
        }

        private void artExhibitsMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ArtExhibitsUserControl());
        }

        private void artistsMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ArtistsUserControl());
        }

        private void artworksMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ArtworksUserControl());
        }

        private void stylesMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new StylesUserControl());
        }

        private void substratesMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new SubstratesUserControl());
        }

        private void techniquesMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new TechniquesUserControl());
        }
    }
}
