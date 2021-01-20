using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MovieProgressTracker
{
    public class ProfileHandling
    {
        #region Members
        private const string ProfileFolder = "Profiles/";
        public static ProfileHandling Instance = new ProfileHandling();

        public List<Movie> Movies = new List<Movie>();
        public List<SwapPair> DriveLetterSwaps = SwapPair.GetAllPairs();
        #endregion

        /// <summary>
        /// Fills the combobox on the main form
        /// </summary>
        /// <param name="cbo"></param>
        public void FillCbo(ref ComboBox cbo)
        {
            cbo.BeginUpdate();

            // Clear
            cbo.Items.Clear();

            // Get the profile paths
            string[] profilePaths = Directory.GetFiles(string.Format("{0}/{1}", Application.StartupPath, ProfileFolder), "*.xml");

            // Add them to the combobox (filename only and no extension)
            foreach (string file in profilePaths)
                cbo.Items.Add(Path.GetFileNameWithoutExtension(file));

            // Set the selected index if possble
            if(cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;

            cbo.EndUpdate();
        }

        /// <summary>
        /// Fills the treeview with the items from the selected profile (loaded from disk)
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="profile"></param>
        public void FillTreeView(ref TreeView tv, string profile)
        {
            #region Open XML
            string fullPath = string.Format("{0}/{1}{2}.xml", Application.StartupPath, ProfileFolder, profile);
            XDocument doc;
            try
            {
                doc = XDocument.Load(fullPath);
            }
            catch
            {
                MessageBox.Show(string.Format("Profile {0} not found. Load aborted. Full path: {1}", profile, fullPath), "Error loading profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            Movies.Clear();

            #region XML -> Memory
            foreach (XElement movieNode in doc.Root.Element("Movies").Elements())
            {
                List<Season> seasons = new List<Season>();
                XElement seasonsMainNode = movieNode.Element("Seasons");
                if (seasonsMainNode != null)
                {
                    foreach (XElement seasonNode in seasonsMainNode.Elements("Season"))
                    {
                        List<Episode> episodes = new List<Episode>();
                        XElement episodesMainNode = seasonNode.Element("Episodes");
                        if (episodesMainNode != null)
                        {
                            foreach (XElement episodeNode in episodesMainNode.Elements("Episode"))
                                episodes.Add(Episode.FromXml(episodeNode));
                        }
                        seasons.Add(Season.FromXml(seasonNode, episodes));
                    }
                }

                Movies.Add(Movie.FromXml(movieNode, seasons));
            }
            #endregion

            #region Memory --> Treeview
            tv.BeginUpdate();
            tv.Nodes.Clear();
            foreach (Movie movie in Movies)
            {
                TreeNode movieNode = new TreeNode(movie.Name) { Checked = movie.Watched };

                foreach (Season season in movie.Seasons)
                {
                    TreeNode seasonNode = new TreeNode(season.Name) { Checked = season.Watched };

                    foreach (Episode episode in season.Episodes)
                    {
                        TreeNode episodeNode = new TreeNode(episode.Name) { Checked = episode.Watched };
                        seasonNode.Nodes.Add(episodeNode);
                    }

                    movieNode.Nodes.Add(seasonNode);
                }

                movieNode.Tag = movie;
                if (Directory.Exists(movie.Directory))
                {
                    movieNode.ForeColor = Color.DarkGreen;
                    movie.HasValidDirectory = true;
                }
                else if (movie.Directory != string.Empty)
                {
                    #region Try swapping the drive-letters
                    string driveLetter = movie.Directory[0].ToString();
                    string pathWithoutDriveLetter = movie.Directory.Substring(1, movie.Directory.Length - 1);
                    foreach (SwapPair swapPair in DriveLetterSwaps)
                    {
                        if (swapPair.A == driveLetter)
                        {
                            string newPath = string.Format("{0}{1}", swapPair.B, pathWithoutDriveLetter);
                            if (Directory.Exists(newPath))
                            {
                                movie.SwappedPath = newPath;
                                movieNode.ForeColor = Color.DarkGreen;
                                movie.HasValidDirectory = true;
                            }
                        }
                        else if (swapPair.B == driveLetter)
                        {
                            string newPath = string.Format("{0}{1}", swapPair.A, pathWithoutDriveLetter);
                            if (Directory.Exists(newPath))
                            {
                                movie.SwappedPath = newPath;
                                movieNode.ForeColor = Color.DarkGreen;
                                movie.HasValidDirectory = true;
                            }
                        }
                    }
                    #endregion
                }
                tv.Nodes.Add(movieNode);
            }

            tv.Sort();
            tv.EndUpdate();
            #endregion
        }

        /// <summary>
        /// Creates a new empty profile and saves it to disk.
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        public bool CreateNew(string profileName)
        {
            string FullSavePath = string.Format("{0}/{1}{2}.xml", Application.StartupPath, ProfileFolder, profileName);

            if (File.Exists(FullSavePath))
            {
                if (MessageBox.Show(string.Format("The file \"{0}\" already exists. Overwrite?",FullSavePath),"Warning, file exists!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }

            try
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                doc.Add(new XElement("Profile"));
                doc.Root.Add(new XElement("Movies"));
                doc.Save(FullSavePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the treeview to disk (XML)
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="profile"></param>
        public void SaveTreeView(TreeView tv, string profile)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            //doc.Add();
            doc.Add(new XElement("Profile"));
            XElement MoviesMainNode = new XElement("Movies");
            doc.Root.Add(MoviesMainNode);

            foreach (TreeNode movieNode in tv.Nodes)
            {
                XElement xMovieNode = new XElement("Movie");
                xMovieNode.Add(new XAttribute("name", movieNode.Text), new XAttribute("watched", movieNode.Checked), new XAttribute("directory", ((Movie)movieNode.Tag).Directory));

                #region Save Genres
                List<string> genres = ((Movie)movieNode.Tag).Genres;
                if (genres.Count > 0)
                {
                    XElement genresMainNode = new XElement("Genres");
                    foreach (string genre in genres)
                        genresMainNode.Add(new XElement("Genre", genre));
                    xMovieNode.Add(genresMainNode);
                }
                #endregion

                if (movieNode.Nodes.Count > 0) // if movie has seasons
                {
                    XElement seasonsMainNode = new XElement("Seasons");

                    foreach (TreeNode seasonNode in movieNode.Nodes)
                    {
                        if (seasonNode.Nodes.Count > 0) // if season has episodes
                        {
                            XElement episodesMainNode = new XElement("Episodes");

                            foreach (TreeNode episodeNode in seasonNode.Nodes)
                            {
                                episodesMainNode.Add(new XElement("Episode",
                                                                    new XAttribute("name", episodeNode.Text),
                                                                    new XAttribute("watched", episodeNode.Checked)
                                                                  ));
                            }

                            seasonsMainNode.Add(new XElement("Season",
                                                                new XAttribute("name", seasonNode.Text),
                                                                new XAttribute("watched", seasonNode.Checked),
                                                                episodesMainNode
                                                            ));
                        }

                        xMovieNode.Add(seasonsMainNode);
                    }

                }
                MoviesMainNode.Add(xMovieNode);
            }

            string FullSavePath = string.Format("{0}/{1}{2}.xml", Application.StartupPath, ProfileFolder, profile);
            doc.Save(FullSavePath);
        }
    }
}
