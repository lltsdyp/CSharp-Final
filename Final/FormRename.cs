using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class FormRename : Form
    {
        public string NewName { get => textBoxNewName.Text; }
        public FormRename()
        {
            InitializeComponent();
        }

        public FormRename(string oldname) : this()
        {
            textBoxNewName.Text = oldname;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormRename_Load(object sender, EventArgs e)
        {
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
