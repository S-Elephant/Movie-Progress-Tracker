using System;
using System.Windows.Forms;

namespace MovieProgressTracker
{
    public partial class frmNewProfile : Form
    {
        public frmNewProfile()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtProfileName.Text == string.Empty)
            {
                MessageBox.Show("Please enter a valid profile name", "No profile name was supplied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filename = Utils.MakeValidFileName(txtProfileName.Text);

            if(ProfileHandling.Instance.CreateNew(filename))
                Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNewProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
