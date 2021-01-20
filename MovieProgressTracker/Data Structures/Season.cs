using System.Collections.Generic;
using System.Xml.Linq;

namespace MovieProgressTracker
{
    public class Season
    {
        #region Members
        public List<Episode> Episodes = new List<Episode>();
        public string Name;
        private bool m_Watched = false;
        public bool Watched
        {
            get { return m_Watched; }
            set{
                m_Watched = value;
                if(value)
                    Episodes.ForEach(e=>e.Watched = true);
            }
        }
        #endregion

        public Season(string name)
        {
            Name = name;
            Watched = false;
        }

        public Season(int number, int episodeCnt)
        {
            Name = string.Format("Season {0:00}", number);
            Watched = false;
            for (int episodeIdx = 1; episodeIdx <= episodeCnt; episodeIdx++)
                Episodes.Add(new Episode(episodeIdx));
        }

        private Season(string name, bool watched, List<Episode> episodes)
        {
            Name = name;
            Episodes = episodes;
            Watched = watched;
        }

        public static Season FromXml(XElement node, List<Episode> episodes)
        {
            return new Season(node.Attribute("name").Value, bool.Parse(node.Attribute("watched").Value), episodes);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}