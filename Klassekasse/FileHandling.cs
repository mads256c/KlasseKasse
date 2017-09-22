using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Klassekasse
{
    public static class FileHandling
    {
        public static List<ListViewItem> OpenFile(string fileName)
        {
            //These variables are used to know which list to put the information from the file into.
            bool diffrence = false;
            bool description = false;

            //The lists
            List<string> diffrenceList = new List<string>();
            List<string> descriptionList = new List<string>();

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Loop over each line in the file the user have opened.
            foreach (string line in File.ReadAllLines(fileName))
            {
                //This case statement make sure that the file contents get put into the right places.
                switch (line)
                {
                    case "[DIFFRENCE]":
                        diffrence = true;
                        description = false;
                        break;
                    case "[DESCRIPTION]":
                        diffrence = false;
                        description = true;
                        break;
                    default:
                        if (diffrence)
                        {
                            diffrenceList.Add(line);
                        }
                        else if (description)
                        {
                            descriptionList.Add(line);
                        }
                        break;
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
                item.SubItems.AddRange(new[] { descriptionList[i], diffrenceList[i] });
                listViewItems.Add(item);
            }
            return listViewItems;
        }

        public static bool SaveFile(string fileName, List<string> diffrence, List<string> description)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (diffrence == null) throw new ArgumentNullException(nameof(diffrence));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("fileName cannot be null empty or whitespace.", nameof(fileName));

            if (diffrence.Count != description.Count)
            {
                return false;
            }
            var lines = new List<string>();
            lines.Add("[DIFFRENCE]");
            lines.AddRange(diffrence);
            lines.Add("[DESCRIPTION]");
            lines.AddRange(description);

            File.WriteAllLines(fileName, lines);
            return true;
        }
    }
}
