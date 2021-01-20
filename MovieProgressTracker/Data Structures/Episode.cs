using System.Xml.Linq;

namespace MovieProgressTracker
{
    public class Episode
    {
        #region Members
        public string Name;
        public bool Watched;
        #endregion

        public Episode(string name)
        {
            Name = name;
            Watched = false;
        }

        public Episode(int number)
        {
            Name = string.Format("Episode {0:000}", number);
            Watched = false;
        }

        private Episode(string name, bool watched)
        {
            Name = name;
            Watched = watched;
        }

        public static Episode FromXml(XElement node)
        {
            return new Episode(node.Attribute("name").Value, bool.Parse(node.Attribute("watched").Value));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
