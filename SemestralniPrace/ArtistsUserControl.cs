using SemestralniPrace.EditForm;
using SemestralniPrace.Model;
using SemestralniPrace.Repository;
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

namespace SemestralniPrace
{
    public partial class ArtistsUserControl : UserControl
    {
        private IRepository<Artist> _artistRepository;

        private Artist artistFilter;

        public ArtistsUserControl()
        {
            _artistRepository = new ArtistRepository();

            InitializeComponent();
            Resize += ArtistsUserControl_Resize;

            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Surname");
            listView.Columns.Add("Birth Date");
            listView.Columns.Add("Death Date");
            listView.Columns.Add("Description");
            listView.FullRowSelect = true;

            RefreshListView();
        }

        private void RefreshListView()
        {
            listView.Items.Clear();
            var artists = _artistRepository.GetList(artistFilter);

            foreach (var artist in artists)
            {
                var item = new ListViewItem(artist.Name);
                item.SubItems.Add(artist.Surname);
                item.SubItems.Add(artist.BirthDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(artist.DeathDate?.ToString("yyyy-MM-dd") ?? "");
                item.SubItems.Add(artist.Description);
                item.Tag = artist.Id;
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

        private void ArtistsUserControl_Resize(object sender, EventArgs e)
        {
            SetEqualColumnWidths();
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            ArtistEditForm dialog = new ArtistEditForm(null);
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _artistRepository.Save(dialog.Artist);
                RefreshListView();
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ArtistEditForm dialog = new ArtistEditForm(_artistRepository.Get((int)listView.SelectedItems[0].Tag));
                DialogResult dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    _artistRepository.Save(dialog.Artist);
                    RefreshListView();
                }
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {listView.SelectedItems.Count} selected artist(s)?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        _artistRepository.Delete((int)item.Tag);
                    }
                }

                RefreshListView();
            }
            else
            {
                MessageBox.Show("No artist has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void importCsvMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Import Artists from CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = _artistRepository.ImportCsv(openFileDialog.FileName);

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
                FileName = "artists_export.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = _artistRepository.ExportCsv(saveFileDialog.FileName, artistFilter);

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
