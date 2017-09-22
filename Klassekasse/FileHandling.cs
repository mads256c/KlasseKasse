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
            bool description = false;
            bool difference = false;

            //The lists
            List<string> descriptionList = new List<string>();
            List<string> differenceList = new List<string>();

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            //Loop over each line in the file the user have opened.
            foreach (var line in File.ReadAllLines(fileName))
            {
                //This case statement make sure that the file contents get put into the right places.
                switch (line)
                {
                    case "[DESCRIPTION]":
                        difference = false;
                        description = true;
                        break;
                    case "[DIFFRENCE]":
                        difference = true;
                        description = false;
                        break;
                    default:
                        if (description)
                        {
                            descriptionList.Add(line);
                        }
                        else if (difference)
                        {
                            differenceList.Add(line);
                        }
                        break;
                }
            }
            //Abort if something went wrong. This does not clear the listview so the users data should be safe.
            if ( descriptionList.Count != differenceList.Count || description == difference)
            {
                return null;
            }
            for (int i = 0; i < differenceList.Count; i++)
            {
                var item = new ListViewItem();
                item.Text = "0";
                item.SubItems.AddRange(new[] { descriptionList[i], differenceList[i] });
                listViewItems.Add(item);
            }
            return listViewItems;
        }

        public static bool SaveFile(string fileName, List<string> description, List<string> difference)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (difference == null) throw new ArgumentNullException(nameof(difference));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("fileName cannot be null empty or whitespace.", nameof(fileName));

            if (difference.Count != description.Count)
            {
                return false;
            }
            var lines = new List<string>();
            lines.Add("[DESCRIPTION]");
            lines.AddRange(description);
            lines.Add("[DIFFRENCE]");
            lines.AddRange(difference);

            File.WriteAllLines(fileName, lines);
            return true;
        }
    }
}
