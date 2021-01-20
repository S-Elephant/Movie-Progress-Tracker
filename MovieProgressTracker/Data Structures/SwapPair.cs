using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System;

namespace MovieProgressTracker
{
    public class SwapPair
    {
        public string A;
        public string B;

        public SwapPair(string a, string b)
        {
            A = a;
            B = b;
        }

        public static List<SwapPair> GetAllPairs()
        {
            List<SwapPair> result = new List<SwapPair>();
            string[] pairs = null;
            try
            {
                pairs = File.ReadAllLines(string.Format("{0}/Settings/DriveLetterSwaps.txt", Application.StartupPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in SwapPair.GetAllPairs()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return result;
            }

            foreach (string pairStr in pairs)
            {
                string[] pair = pairStr.Split(';');
                result.Add(new SwapPair(pair[0], pair[1]));
            }

            return result;
        }
    }
}