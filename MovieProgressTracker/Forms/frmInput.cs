using System;
using System.Windows.Forms;

namespace MovieProgressTracker
{
    public partial class frmInput : Form
    {
        /// <summary>
        /// The string that contains the input
        /// </summary>
        public static string InputStr;

        public frmInput(string initialValue, string title)
        {
            InitializeComponent();
            InputStr = string.Empty;
            this.DialogResult = DialogResult.None;
            txtInput.Text = initialValue;
            Text = title;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InputStr = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InputStr = txtInput.Text;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
