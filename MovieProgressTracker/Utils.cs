using System.IO;
using System.Text.RegularExpressions;

namespace MovieProgressTracker
{
    public static class Utils
    {
        /// <summary>
        /// Converts (if needed) the string to a valid filename
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            return Regex.Replace(name, invalidReStr, "_");
        }

    }
}
