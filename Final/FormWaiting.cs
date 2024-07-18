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
    public partial class FormWaiting : Form
    {
        private CancellationTokenSource cts;
        public FormWaiting()
        {
            this.cts = new CancellationTokenSource();
            InitializeComponent();
        }

        public FormWaiting(CancellationTokenSource cts) : this()
        {
            this.cts = cts;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWaiting_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
