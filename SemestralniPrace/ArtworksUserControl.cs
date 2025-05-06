using SemestralniPrace.EditForm;
using SemestralniPrace.FilterForm;
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

namespace SemestralniPrace
{
    public partial class ArtworksUserControl : UserControl
    {
        private ArtworkRepository artworkRepository;
        private Artwork artworkFilter;

        public ArtworksUserControl()
        {
            artworkRepository = new ArtworkRepository();
            artworkFilter = new Artwork();

            InitializeComponent();
            Resize += ArtworksUserControl_Resize;

            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Description");
            listView.Columns.Add("Width");
            listView.Columns.Add("Height");
            listView.Columns.Add("Date Published");
            listView.Columns.Add("Style");
            listView.Columns.Add("Substrate");
            listView.Columns.Add("Technique");
            listView.Columns.Add("Artist");
            listView.Columns.Add("Art Exhibit");
            listView.FullRowSelect = true;
            listView.KeyDown += ListView_KeyDown;

            RefreshListView();
        }

        private void RefreshListView()
        {
            listView.Items.Clear();
            var artworks = artworkRepository.GetList(artworkFilter);

            foreach (var artwork in artworks)
            {
                var item = new ListViewItem(artwork.Name);
                item.SubItems.Add(artwork.Description);
                item.SubItems.Add(artwork.Width.ToString());
                item.SubItems.Add(artwork.Height.ToString());
                item.SubItems.Add(artwork.DatePublished.ToString("yyyy-MM-dd"));
                item.SubItems.Add(artwork.Style.Name);
                item.SubItems.Add(artwork.Substrate.Name);
                item.SubItems.Add(artwork.Technique.Name);
                item.SubItems.Add(artwork.Artist.FullName);
                item.SubItems.Add(artwork.ArtExhibit?.Name ?? "");
                item.Tag = artwork.Id;
                listView.Items.Add(item);
            }
        }

        private void SetEqualColumnWidths()
        {
            if (listView.Columns.Count <= 0) return;

            int totalWidth = listView.ClientSize.Width;
            int columnWidth = totalWidth / listView.Columns.Count;

            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = columnWidth;
            }
        }

        private void ArtworksUserControl_Resize(object sender, EventArgs e)
        {
            SetEqualColumnWidths();
        }

        private void ListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    addMenuItem_Click(sender, e);
                    break;
                case Keys.E:
                    editMenuItem_Click(sender, e);
                    break;
                case Keys.Delete:
                case Keys.D:
                    deleteMenuItem_Click(sender, e);
                    break;
                case Keys.F:
                    filterMenuItem_Click(sender, e);
                    break;
                default:
                    return;
            }

            e.Handled = true;
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            ArtworkEditForm dialog = new ArtworkEditForm(null);
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                artworkRepository.Save(dialog.Artwork);
                RefreshListView();
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ArtworkEditForm dialog = new ArtworkEditForm(artworkRepository.Get((int)listView.SelectedItems[0].Tag));
                DialogResult dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    artworkRepository.Save(dialog.Artwork);
                    RefreshListView();
                }
            }
            else
            {
                MessageBox.Show("No artist has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {listView.SelectedItems.Count} selected artwork(s)?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        artworkRepository.Delete((int)item.Tag);                        
                    }
                }

                RefreshListView();
            }
            else
            {
                MessageBox.Show("No artwork has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            ArtworkFilterForm dialog = new ArtworkFilterForm(artworkFilter);
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                artworkFilter = dialog.ArtworkFilter;
                RefreshListView();
            }
        }

        private void importCsvMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Import Artworks from CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = artworkRepository.ImportCsv(openFileDialog.FileName);

                if (success)
                {
                    MessageBox.Show("All items from the imported file have been saved to the database.", "Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshListView();
                }
                else
                {
                    MessageBox.Show("Some items from the imported file may be missing due to incorrect formatting or missing non-nullable attributes.", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            RefreshListView();
        }

        private void exportCsvMenuItem_Click(object sender, EventArgs e)
        {
            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Export Artists to CSV",
                FileName = "artworks_export.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = artworkRepository.ExportCsv(saveFileDialog.FileName, artworkFilter);

                if (success)
                {
                    MessageBox.Show("All filtered items have been saved to the exported file.", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An unexpected error has occurred during the export process.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            RefreshListView();
        }
    }
}
