using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Klassekasse
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Calculates the Saldo by going though all the items in listView
        /// </summary>
        private void CalculateSaldo()
        {
            decimal saldo = 0;
            foreach (ListViewItem item in listView.Items)
            {
                item.UseItemStyleForSubItems = false;
                saldo += decimal.Parse(item.SubItems[2].Text);
                item.Text = saldo.ToString(CultureInfo.CurrentCulture);

                //Set the color of the saldo and difference to red if less than 0 else normal color
                item.SubItems[0].ForeColor = saldo < 0 ? Color.Red : SystemColors.ControlText;
                item.SubItems[2].ForeColor = decimal.Parse(item.SubItems[2].Text) < 0 ? Color.Red : SystemColors.ControlText;

            }

            labelSaldo.Text = $"Saldo: {saldo}";
        }

        /// <summary>
        /// Applies the edits from FormTransactionEdit
        /// </summary>
        private void ApplyEdits(TransactionData transactionData)
        {
                listView.SelectedItems[0].SubItems[1].Text = transactionData.Description.Replace(Environment.NewLine, "");
                listView.SelectedItems[0].SubItems[2].Text = transactionData.Difference.ToString(CultureInfo.CurrentCulture);
                CalculateSaldo();
        }

        private void InsertAbove()
        {
            if (listView.SelectedItems.Count == 1)
            {
                using (FormTransactionEdit formTransactionEdit = new FormTransactionEdit())
                {
                    if (formTransactionEdit.ShowDialog() == DialogResult.OK)
                    {
                        var item = new ListViewItem();
                        decimal multiplier;
                        if (formTransactionEdit.TransactionData.IsDeposit)
                        {
                            multiplier = 1;
                        }
                        else
                        {
                            multiplier = -1;
                        }

                        item.SubItems.AddRange(new[] { formTransactionEdit.TransactionData.Description, (formTransactionEdit.TransactionData.Difference * multiplier).ToString(CultureInfo.CurrentCulture)});
                        listView.Items.Insert(listView.Items.IndexOf(listView.SelectedItems[0]), item);
                        CalculateSaldo();
                    }
                }
                
            }
        }

        private void InsertBelow()
        {
            if (listView.SelectedItems.Count == 1)
            {
                using (FormTransactionEdit formTransactionEdit = new FormTransactionEdit())
                {
                    if (formTransactionEdit.ShowDialog() == DialogResult.OK)
                    {
                        var item = new ListViewItem();
                        item.SubItems.AddRange(new[] { formTransactionEdit.TransactionData.Description, formTransactionEdit.TransactionData.Difference.ToString(CultureInfo.CurrentCulture) });
                        listView.Items.Insert(listView.Items.IndexOf(listView.SelectedItems[0]) + 1, item);
                        CalculateSaldo();
                    }
                }

            }
        }


        /// <summary>
        /// Edits the selected item
        /// </summary>
        private void EditSelectedItem()
        {
            //Checks if the user has selected only one row.
            if (listView.SelectedItems.Count == 1)
            {
                using (var formTransactionEdit = new FormTransactionEdit(listView.SelectedItems[0].SubItems[1].Text, decimal.Parse(listView.SelectedItems[0].SubItems[2].Text), !(decimal.Parse(listView.SelectedItems[0].SubItems[2].Text) < 0)))
                {
                    if (formTransactionEdit.ShowDialog() == DialogResult.OK)
                    {
                        ApplyEdits(formTransactionEdit.TransactionData);
                    }
                }
            }
            else
            {
                MessageBox.Show("Makér en række."); //Tell the user to only select one row.
            }
        }

        /// <summary>
        /// Deletes the items that are selected.
        /// </summary>
        private void DeleteSelectedItems()
        {
            //Checks if the user has selected only one row.
            if (listView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Er du sikker på at du vil fjerne denne række?", "Er du sikker?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        item.Remove();
                    }
                    CalculateSaldo();
                }
            }
            else
            {
                MessageBox.Show("Makér en række."); //Tell the user to only select one row.
            }
        }

        /// <summary>
        /// Opens the save as dialog and saves the file to that location.
        /// </summary>
        private void SaveAs()
        {
            //If the user chose a filename and everything went right save the file.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Save(saveFileDialog.FileName);
        }

        /// <summary>
        /// Saves with the name fileName.
        /// </summary>
        private void Save(string fileName)
        {
            //If argument is invalid throw an exception
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("Argument cannot be null or empty", nameof(fileName));

            //Take all info from the listview and put it into lists so it we later can save them in a file
            var descriptionList = new List<string>();
            var differenceList = new List<string>();
            foreach (ListViewItem item in listView.Items)
            {
                descriptionList.Add(item.SubItems[1].Text);
                differenceList.Add(item.SubItems[2].Text);
            }
            //Try to save the file and show a messagebox that describes how it went
            MessageBox.Show(FileHandling.SaveFile(saveFileDialog.FileName, descriptionList, differenceList)
                ? "Saved file successfully!"
                : "Something went wrong!");
        }

        /// <summary>
        /// Fires when the Edit button is pressed.
        /// </summary>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        /// <summary>
        /// Fires when the Remove button is pressed.
        /// </summary>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DeleteSelectedItems();

        }

        /// <summary>
        /// Fires when the Add button is pressed.
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (FormTransactionEdit formTransactionEdit = new FormTransactionEdit())
            {
                if (formTransactionEdit.ShowDialog() == DialogResult.OK)
                {
                    var item = new ListViewItem();
                    item.SubItems.AddRange(new []{formTransactionEdit.TransactionData.Description, formTransactionEdit.TransactionData.Difference.ToString(CultureInfo.CurrentCulture)});
                    listView.Items.Add(item);
                    CalculateSaldo();
                }
            }
        }

        private void afslutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void åbnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var listViewItems = FileHandling.OpenFile(openFileDialog.FileName);
                if (listViewItems == null)
                {
                    MessageBox.Show("File malformed or corrupt. Please correct the file.");
                }
                else
                {
                    listView.Items.Clear();
                    listView.Items.AddRange(listViewItems.ToArray());
                    CalculateSaldo();
                }

            }

        }

        private void gemSomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        /// <summary>
        /// Fires when the form loads
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            openFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.InitialDirectory = Application.StartupPath;
#endif
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewcontextMenuStrip.Show(Cursor.Position);
            }
        }

        private void aboveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertAbove();
        }

        private void underToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertBelow();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedItems();
        }
    }
}
