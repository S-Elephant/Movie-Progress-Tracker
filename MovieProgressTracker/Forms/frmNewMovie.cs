using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MovieProgressTracker
{
    public partial class frmNewMovie : Form
    {
        #region Members
        // For the main form's saved status
        public static bool MovieWasCreated;

        // The treeview from the main form
        private TreeView tvMovies;
        #endregion

        public frmNewMovie(ref TreeView tv)
        {
            tvMovies = tv;
            MovieWasCreated = false;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CreateMovie()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please enter a valid profile name", "No profile name was supplied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtGenres.Text == string.Empty)
            {
                if (MessageBox.Show("Are you sure you DON'T want to add any genre at all?", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            // Create movie with optional numeric seasons and episodes
            Movie newMovie = new Movie(txtName.Text.Replace(">", "]").Replace("<", "["), txtDirectory.Text, txtGenres.Text.Split(';').ToList(), int.Parse(txtSeasons.Text), int.Parse(txtEpisodes.Text));

            // Add custom seasons (if any)
            foreach (Season customSeason in lstCustomSeasons.Items)
                newMovie.Seasons.Add(customSeason);

            tvMovies.BeginUpdate();
            TreeNode newMovieNode = new TreeNode(newMovie.Name) { Tag = newMovie };
            foreach (Season season in newMovie.Seasons)
            {
                TreeNode newSeasonNode = new TreeNode(season.Name);
                foreach (Episode episode in season.Episodes)
                {
                    newSeasonNode.Nodes.Add(new TreeNode(episode.Name));
                }
                newMovieNode.Nodes.Add(newSeasonNode);
            }

            if (Directory.Exists(newMovie.Directory))
            {
                newMovieNode.ForeColor = Color.DarkGreen;
                newMovie.HasValidDirectory = true;
            }

            tvMovies.Nodes.Add(newMovieNode);
            tvMovies.Sort();
            tvMovies.EndUpdate();

            MovieWasCreated = true;

            // Reset
            txtName.Clear();
            txtGenres.Clear();
            txtDirectory.Clear();
            txtEpisodes.Text = txtSeasons.Text = "0";
            txtName.Focus();

            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMovie();
        }

        private void frmNewMovie_Load(object sender, EventArgs e)
        {
            string[] genres = File.ReadAllLines(string.Format("{0}/Settings/Genres.txt", Application.StartupPath));
            foreach (string genre in genres)
                lstGenres.Items.Add(genre);
        }

        private void lstGenres_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddSelGenres_Click(null, null);
            }
        }

        private void txtSeasons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void txtEpisodes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void btnAddSelGenres_Click(object sender, EventArgs e)
        {
            foreach (string genre in lstGenres.SelectedItems)
            {
                if (txtGenres.Text == string.Empty)
                    txtGenres.Text = genre;
                else
                    txtGenres.Text += ";" + genre;
            }
        }

        private void btnCreateAndClose_Click(object sender, EventArgs e)
        {
            if(CreateMovie())
                Close();
        }

        private void btnGenreHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comma seperated. For example: \"Horror;Anime;Thriller\" (without the quotes).", "Genre Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lstDelete_KeyUp(object sender, KeyEventArgs e)
        {
            ListBox lstSender = (ListBox)sender;
            if (e.KeyCode == Keys.Delete && lstSender.SelectedIndex != -1)
                lstSender.Items.Remove(lstSender.SelectedItem);
        }

        private void GetCustomEpisodes()
        {
            lstCustomEpisodes.BeginUpdate();
            lstCustomEpisodes.Items.Clear();

            if (lstCustomSeasons.SelectedIndex != -1)
            {
                Season selSeason = (Season)lstCustomSeasons.SelectedItem;
                foreach (Episode e in selSeason.Episodes)
                {
                    lstCustomEpisodes.Items.Add(e);
                }
            }
            lstCustomEpisodes.EndUpdate();
        }

        private void lstCustomSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomEpisodes();
        }

        private void txtCustomSeason_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustomSeason.Text != string.Empty)
            {
                lstCustomSeasons.Items.Add(new Season(txtCustomSeason.Text));                
                txtCustomSeason.Clear();
            }
        }

        private void txtCustomEpisode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstCustomSeasons.SelectedIndex != -1 && txtCustomEpisode.Text != string.Empty)
            {
                Season selSeason = (Season)lstCustomSeasons.SelectedItem;
                selSeason.Episodes.Add(new Episode(txtCustomEpisode.Text));
                txtCustomEpisode.Clear();
                GetCustomEpisodes();
            }
        }

        private void lstGenres_DoubleClick(object sender, EventArgs e)
        {
            btnAddSelGenres_Click(null, null);
        }
    }
}