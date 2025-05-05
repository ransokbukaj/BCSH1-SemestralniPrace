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
    public partial class SubstratesUserControl : UserControl
    {
        private SubstrateRepository substrateRepository;
        private BaseModel substrateFilter;

        public SubstratesUserControl()
        {
            substrateRepository = new SubstrateRepository();
            substrateFilter = new BaseModel();

            InitializeComponent();
            Resize += SubstratesUserControl_Resize;

            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Description");
            listView.FullRowSelect = true;
            listView.KeyDown += ListView_KeyDown;

            RefreshListView();
        }

        private void RefreshListView()
        {
            listView.Items.Clear();
            var substrates = substrateRepository.GetList(substrateFilter);

            foreach (var substrate in substrates)
            {
                var item = new ListViewItem(substrate.Name);
                item.SubItems.Add(substrate.Description);
                item.Tag = substrate.Id;
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

        private void SubstratesUserControl_Resize(object sender, EventArgs e)
        {
            SetEqualColumnWidths();
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            BaseModelEditForm dialog = new BaseModelEditForm(null, "Add Substrate");
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                substrateRepository.Save(dialog.BaseModel);
                RefreshListView();
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                BaseModelEditForm dialog = new BaseModelEditForm(substrateRepository.Get((int)listView.SelectedItems[0].Tag), "Edit Substrate");
                DialogResult dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    substrateRepository.Save(dialog.BaseModel);
                    RefreshListView();
                }
            }
            else
            {
                MessageBox.Show("No substrate has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {listView.SelectedItems.Count} selected substrate(s)?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        if (!substrateRepository.Delete((int)item.Tag))
                        {
                            MessageBox.Show($"{item.Text} could not be deleted due to being asigned to existing artworks.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                RefreshListView();
            }
            else
            {
                MessageBox.Show("No substrate has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            BaseModelFilterForm dialog = new BaseModelFilterForm(substrateFilter, "Filter Substrates");
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                substrateFilter = dialog.BaseModelFilter;
                RefreshListView();
            }
        }

        private void importCsvMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Import Substrates from CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = substrateRepository.ImportCsv(openFileDialog.FileName);

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
                Title = "Export Substrates to CSV",
                FileName = "substrates_export.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = substrateRepository.ExportCsv(saveFileDialog.FileName, substrateFilter);

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
