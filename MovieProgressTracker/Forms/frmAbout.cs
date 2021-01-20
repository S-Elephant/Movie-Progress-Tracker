using System;
using System.IO;
using System.Windows.Forms;

namespace MovieProgressTracker
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = string.Format("Movie Progress Tracker - Version {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            try
            {
                txtAbout.Text = File.ReadAllText(string.Format("{0}/ReadMe.txt", Application.StartupPath));
            }
            catch
            {
                txtAbout.Text = "Error: ReadMe.txt not found. What did you do to my readme file (o.O) ?";
            }
        }
    }
}
