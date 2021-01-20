using System.Collections.Generic;
using System.Xml.Linq;

namespace MovieProgressTracker
{
    public class Movie
    {
        #region
        public List<string> Genres = new List<string>();
        public string Name;
        private bool m_Watched = false;
        public bool Watched
        {
            get { return m_Watched; }
            set
            {
                m_Watched = value;
                if (value)
                    Seasons.ForEach(s => s.Watched = true);
            }
        }
        public List<Season> Seasons = new List<Season>();
        public string Directory;

        /// <summary>
        /// This member is NOT saved to the XML file
        /// </summary>
        public string SwappedPath = string.Empty;

        /// <summary>
        /// Either regular or swapped
        /// </summary>
        public bool HasValidDirectory = false;
        #endregion

        public Movie(string name, string directory, List<string> genres, int seasonCnt, int episodeCnt)
        {
            Name = name;
            Watched = false;
            Directory = directory;
            for (int seasonIdx = 1; seasonIdx <= seasonCnt; seasonIdx++)
                Seasons.Add(new Season(seasonIdx, episodeCnt));
            Genres = genres;
            Genres.RemoveAll(g => g == string.Empty); // remove any possible empty values.
        }

        private Movie(string name, bool watched, string directory, List<Season> seasons)
        {
            Name = name;
            Seasons = seasons;
            Watched = watched;
            Directory = directory;
        }

        public static Movie FromXml(XElement node, List<Season> seasons)
        {
            Movie result = new Movie(node.Attribute("name").Value, bool.Parse(node.Attribute("watched").Value), node.Attribute("directory").Value, seasons);

            #region Load genres
            XElement GenresMainNode = node.Element("Genres");
            if (GenresMainNode != null)
            {
                foreach (XElement genreNode in node.Element("Genres").Elements("Genre"))
                    result.Genres.Add(genreNode.Value);
            }
            #endregion

            return result;
        }
    }
}
