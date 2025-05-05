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
    public partial class StylesUserControl : UserControl
    {
        private StyleRepository styleRepository;
        private BaseModel styleFilter;

        public StylesUserControl()
        {
            styleRepository = new StyleRepository();
            styleFilter = new BaseModel();

            InitializeComponent();
            Resize += StylesUserControl_Resize;

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
            var styles = styleRepository.GetList(styleFilter);

            foreach (var style in styles)
            {
                var item = new ListViewItem(style.Name);
                item.SubItems.Add(style.Description);
                item.Tag = style.Id;
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

        private void StylesUserControl_Resize(object sender, EventArgs e)
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
            BaseModelEditForm dialog = new BaseModelEditForm(null, "Add Style");
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                styleRepository.Save(dialog.BaseModel);
                RefreshListView();
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                BaseModelEditForm dialog = new BaseModelEditForm(styleRepository.Get((int)listView.SelectedItems[0].Tag), "Edit Style");
                DialogResult dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    styleRepository.Save(dialog.BaseModel);
                    RefreshListView();
                }
            }
            else
            {
                MessageBox.Show("No style has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {listView.SelectedItems.Count} selected style(s)?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        if (!styleRepository.Delete((int)item.Tag))
                        {
                            MessageBox.Show($"{item.Text} could not be deleted due to being asigned to existing artworks.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                RefreshListView();
            }
            else
            {
                MessageBox.Show("No style has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            BaseModelFilterForm dialog = new BaseModelFilterForm(styleFilter, "Filter Styles");
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                styleFilter = dialog.BaseModelFilter;
                RefreshListView();
            }
        }

        private void importCsvMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Import Styles from CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = styleRepository.ImportCsv(openFileDialog.FileName);

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
                Title = "Export Styles to CSV",
                FileName = "styles_export.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = styleRepository.ExportCsv(saveFileDialog.FileName, styleFilter);

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
