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
    public partial class BaseModelFilterForm : Form
    {
        public BaseModel BaseModelFilter;

        public BaseModelFilterForm(BaseModel baseModel, string title)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            BaseModelFilter = baseModel;
            Text = title;

            if (BaseModelFilter != null)
            {
                textBoxName.Text = BaseModelFilter.Name;
                textBoxDescription.Text = BaseModelFilter.Description;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BaseModelFilter = new BaseModel
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
            };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
