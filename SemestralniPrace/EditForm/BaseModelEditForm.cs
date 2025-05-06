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

namespace SemestralniPrace.EditForm
{
    public partial class BaseModelEditForm : Form
    {
        public BaseModel BaseModel;

        public BaseModelEditForm(BaseModel baseModel, string title)
        {
            InitializeComponent();
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            BaseModel = baseModel;
            Text = title;

            if (BaseModel != null && BaseModel.Id != 0)
            {
                textBoxName.Text = BaseModel.Name;
                textBoxDescription.Text = BaseModel.Description;
            }

            textBoxName.TextChanged += (s, e) => UpdateOkButtonState();

            UpdateOkButtonState();
        }

        private void UpdateOkButtonState()
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(textBoxName.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BaseModel = new BaseModel(BaseModel?.Id ?? 0, textBoxName.Text, textBoxDescription.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
