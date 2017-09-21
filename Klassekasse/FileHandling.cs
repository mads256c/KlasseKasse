using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Klassekasse
{
    public static class FileHandling
    {
        public static List<ListViewItem> OpenFile(string FileName)
        {
            //These variables are used to know which list to put the information from the file into.
            bool diffrence = false;
            bool description = false;

            //The lists
            List<string> diffrenceList = new List<string>();
            List<string> descriptionList = new List<string>();

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Loop over each line in the file the user have opened.
            foreach (string line in File.ReadAllLines(FileName))
            {
                //These two if statements make sure that the file contents get put into the right places.
                if (line == "[DIFFRENCE]")
                {
                    diffrence = true;
                    description = false;
                }
                else if (line == "[DESCRIPTION]")
                {
                    diffrence = false;
                    description = true;
                }
                else
                {
                    if (diffrence)
                    {
                        diffrenceList.Add(line);
                    }
                    else if (description)
                    {
                        descriptionList.Add(line);
                    }
                }
            }
            //Abort if something went wrong. This does not clear the listview so the users data should be safe.
            if (diffrenceList.Count != descriptionList.Count || diffrence == description)
            {
                return null;
            }
            for (int i = 0; i < diffrenceList.Count; i++)
            {
                var item = new ListViewItem();
                item.Text = "0";
                item.SubItems.AddRange(new string[] { descriptionList[i], diffrenceList[i] });
                listViewItems.Add(item);
            }
            return listViewItems;
        }

        public static bool SaveFile(string FileName, List<string> Diffrence, List<string> Description)
        {
            if (Diffrence.Count != Description.Count)
            {
                return false;
            }
            List<string> lines = new List<string>();
            lines.Add("[DIFFRENCE]");
            lines.AddRange(Diffrence);
            lines.Add("[DESCRIPTION]");
            lines.AddRange(Description);

            File.WriteAllLines(FileName, lines);
            return true;
        }
    }
}
