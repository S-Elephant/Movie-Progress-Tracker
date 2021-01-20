using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MovieProgressTracker
{
    public partial class frmMain : Form
    {
        private List<string> MovieFilter = new List<string>();

        private const string TITLE = "Movie Progress Tracker";
        private const string TITLE_UNSAVED = "Movie Progress Tracker* (not saved)";

        private bool m_IsLocked = false;
        public bool IsLocked
        {
            get { return m_IsLocked; }
            set
            {
                m_IsLocked = value;

                if (value)
                {
                    btnLock.BackColor = Color.Red;
                    btnLock.Text = "Unlock";
                }
                else
                {
                    btnLock.BackColor = Color.Transparent;
                    btnLock.Text = "Lock";
                }
            }
        }

        private bool m_ProfileIsSaved = true;
        public bool ProfileIsSaved
        {
            get { return m_ProfileIsSaved; }
            set
            {
                m_ProfileIsSaved = value;
                if (value)
                    Text = TITLE;
                else
                    Text = TITLE_UNSAVED;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ProfileHandling.Instance.FillCbo(ref cboProfile);

            #region Fill filter
            string[] genres = File.ReadAllLines(string.Format("{0}/Settings/Genres.txt", Application.StartupPath));
            foreach (string genre in genres)
            {
                chkLstGenreFilter.Items.Add(genre);
                MovieFilter.Add(genre); // by default add all genres to the filter
            }

            // Check all items
            for (int i = 0; i < chkLstGenreFilter.Items.Count; i++)
                chkLstGenreFilter.SetItemChecked(i, true);

            // Add event handler AFTER we checked all items
            chkLstGenreFilter.ItemCheck += new ItemCheckEventHandler(chkLstGenreFilter_ItemCheck);
            #endregion
        }

        private string PreviousProfile = null;
        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ProfileIsSaved && MessageBox.Show("Would you like to save the changes to your current profile?\nIf not you will lose them.", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ProfileHandling.Instance.SaveTreeView(tvMovies, PreviousProfile);
                ProfileIsSaved = true;
            }

            if (cboProfile.SelectedIndex != -1)
                ProfileHandling.Instance.FillTreeView(ref tvMovies, cboProfile.SelectedItem.ToString());

            PreviousProfile = cboProfile.SelectedItem.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboProfile.SelectedIndex != -1)
                Save();
        }

        private void Save()
        {
            ProfileHandling.Instance.SaveTreeView(tvMovies, cboProfile.SelectedItem.ToString());
            ProfileIsSaved = true;
        }

        private void tvMovies_DoubleClick(object sender, EventArgs e)
        {
            btnOpen_Click(null, null);
        }

        private void OpenDirectoryRecursively(TreeNode node)
        {
            if (node.Tag != null )
            {
                string dir = ((Movie)node.Tag).Directory;
                string swappedDir = ((Movie)node.Tag).SwappedPath;

                if (Directory.Exists(dir))
                {
                    try
                    {
                        Process.Start(dir);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Path {0}\nError: {1}", dir, ex), "Could not open folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Directory.Exists(swappedDir))
                {
                    try
                    {
                        Process.Start(swappedDir);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Path {0}\nError: {1}", swappedDir, ex), "Could not open folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (node.Parent != null)
                    OpenDirectoryRecursively(node.Parent);
            }
        }

        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewProfile frmNewProfile = new frmNewProfile();
            frmNewProfile.ShowDialog();

            int selIdx = cboProfile.SelectedIndex;
            ProfileHandling.Instance.FillCbo(ref cboProfile);
            if (cboProfile.Items.Count >= selIdx)
                cboProfile.SelectedIndex = selIdx;
        }

        private void newMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewMovie frmNewMovie = new frmNewMovie(ref tvMovies);
            frmNewMovie.ShowDialog();

            if (frmNewMovie.MovieWasCreated)
                ProfileIsSaved = false;
        }

        private void tvMovies_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ProfileIsSaved = false;

            if (e.Node.Checked)
            {
                foreach (TreeNode childNode in e.Node.Nodes)
                    HandleAllChildNodes(childNode, e.Node.Checked);
            }
        }

        private void HandleAllChildNodes(TreeNode parentNode, bool checkValue)
        {
            parentNode.Checked = checkValue;
            foreach (TreeNode node in parentNode.Nodes)
                HandleAllChildNodes(node, checkValue);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ProfileIsSaved && MessageBox.Show("Would you like to save the changes to your current profile?\nIf not you will lose them.", "Save?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }

        private void tvMovies_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && tvMovies.SelectedNode != null)
            {
                tvMovies.Nodes.Remove(tvMovies.SelectedNode);
                ProfileIsSaved = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tvMovies.SelectedNode != null)
                OpenDirectoryRecursively(tvMovies.SelectedNode);
        }

        private TreeNode GetParentNode(TreeNode node)
        {
            if(node.Parent != null)
                return GetParentNode(node.Parent);
            else
                return node;
        }

        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {

            btnOpen.Enabled = (tvMovies.SelectedNode != null && ((Movie)GetParentNode(tvMovies.SelectedNode).Tag).HasValidDirectory);
        }

        private void ApplyFilter()
        {
            tvMovies.BeginUpdate();
            foreach (TreeNode topNode in tvMovies.Nodes)
            {
                Movie movie = (Movie)topNode.Tag;
                bool movieIsAllowed = false;
                if (movie.Genres.Count > 0)
                {
                    foreach (string genre in movie.Genres)
                    {
                        foreach (string allowedGenre in MovieFilter)
                        {
                            if (genre == allowedGenre)
                            {
                                movieIsAllowed = true;
                                break;
                            }
                        }
                        if (movieIsAllowed)
                            break;
                    }
                }
                else
                    movieIsAllowed = true;

                if (movieIsAllowed)
                {
                    if(((Movie)topNode.Tag).HasValidDirectory)
                        topNode.ForeColor = Color.DarkGreen;
                    else
                        topNode.ForeColor = Color.Black;
                }
                else
                    topNode.ForeColor = Color.LightGray;
            }
            tvMovies.EndUpdate();
        }

        private void chkLstGenreFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MovieFilter.Clear();
            foreach (string genre in chkLstGenreFilter.CheckedItems)
                MovieFilter.Add(genre);
            if (e.NewValue == CheckState.Checked)
                MovieFilter.Add(chkLstGenreFilter.Items[e.Index].ToString());
            else
                MovieFilter.Remove(chkLstGenreFilter.Items[e.Index].ToString());
            ApplyFilter();
        }

        private void btnCheckAllFilter_Click(object sender, EventArgs e)
        {
            tvMovies.BeginUpdate();
            for (int i = 0; i < chkLstGenreFilter.Items.Count; i++)
                chkLstGenreFilter.SetItemChecked(i, true);
            tvMovies.EndUpdate();
        }

        private void btnUncheckAllfilter_Click(object sender, EventArgs e)
        {
            tvMovies.BeginUpdate();
            for (int i = 0; i < chkLstGenreFilter.Items.Count; i++)
                chkLstGenreFilter.SetItemChecked(i, false);
            tvMovies.EndUpdate();
        }

        private void openProfileFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(string.Format("{0}/Profiles", Application.StartupPath));
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            IsLocked = !IsLocked;
        }

        private void tvMovies_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (IsLocked)
                e.Cancel = true;
        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selNode = (TreeNode)cmsTV.Tag;
            frmInput frmInput = new frmInput(selNode.Text, "Please enter the new name");
            if (frmInput.ShowDialog() == DialogResult.OK)
            {
                if (selNode.Text != frmInput.InputStr)
                {
                    selNode.Text = frmInput.InputStr;
                    ProfileIsSaved = false;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selNode = (TreeNode)cmsTV.Tag;
            if (MessageBox.Show(string.Format("Are you sure you want to delete \"{0}\" including all child nodes (if any)?", selNode.Text), "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tvMovies.Nodes.Remove(selNode);
                ProfileIsSaved = false;
            }
        }

        private void tvMovies_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !IsLocked)
            {
                // Select the clicked node
                tvMovies.SelectedNode = tvMovies.GetNodeAt(e.X, e.Y);

                if (tvMovies.SelectedNode != null)
                {
                    cmsTV.Tag = tvMovies.SelectedNode;
                    cmsTV.Show(tvMovies, e.Location);
                }
            }
        }
    }
}
