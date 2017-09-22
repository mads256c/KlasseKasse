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

                item.SubItems[0].ForeColor = saldo < 0 ? Color.Red : SystemColors.ControlText;

                item.SubItems[2].ForeColor = decimal.Parse(item.SubItems[2].Text) < 0 ? Color.Red : SystemColors.ControlText;

            }

            labelSaldo.Text = $"Saldo: {saldo}";
        }

        /// <summary>
        /// Applies the edits from FormTransactionEdit
        /// </summary>
        private void ApplyEdits()
        {
            if (FormTransactionEdit.Description != null && FormTransactionEdit.Diffrence != null)
            {
                listView.SelectedItems[0].SubItems[1].Text = FormTransactionEdit.Description.Replace(Environment.NewLine, "");
                listView.SelectedItems[0].SubItems[2].Text = FormTransactionEdit.Diffrence.ToString();
            }
            CalculateSaldo();
        }

        /// <summary>
        /// Opens the save as dialog and saves the file to that location.
        /// </summary>
        private void SaveAs()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Saves with the name FileName.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        private void Save(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(fileName));
            }

            List<string> diffrenceList = new List<string>();
            List<string> descriptionList = new List<string>();
            foreach (ListViewItem item in listView.Items)
            {

                diffrenceList.Add(item.SubItems[2].Text);
                descriptionList.Add(item.SubItems[1].Text);
            }

            MessageBox.Show(FileHandling.SaveFile(saveFileDialog.FileName, diffrenceList, descriptionList)
                ? "Saved file successfully!"
                : "Something went wrong!");
        }

        /// <summary>
        /// Fires when the Edit button is pressed.
        /// </summary>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //Checks if the user has selected only one row.
            if (listView.SelectedItems.Count == 1)
            {
                //Creates a new FormTransactionEdit and passes values from listView into the form so they can be edited. Then it opens the form
                new FormTransactionEdit(listView.SelectedItems[0].SubItems[1].Text, decimal.Parse(listView.SelectedItems[0].SubItems[2].Text)).ShowDialog(); // This function blocks this thread, so we have the values when we are done.
                ApplyEdits();
            }
            else
            {
                MessageBox.Show("Makér en række."); //Tell the user to only select one row.
            }
        }

        /// <summary>
        /// Fires when the Remove button is pressed.
        /// </summary>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Checks if the user has selected only one row.
            if (listView.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Er du sikker på at du vil fjerne denne række?", "Er du sikker?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    listView.SelectedItems[0].Remove(); // Removes the selected row.
                    CalculateSaldo();
                }
            }
            else
            {
                MessageBox.Show("Makér en række."); //Tell the user to only select one row.
            }

        }

        /// <summary>
        /// Fires when the Add button is pressed.
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Ask the user about row information
            new FormTransactionEdit().ShowDialog(); // This function blocks this thread, so we have the values when we are done.

            //Return if one of the values are null
            if (FormTransactionEdit.Description != null && FormTransactionEdit.Diffrence != null)
            {
                //Create a new ListViewItem
                ListViewItem item = new ListViewItem();
                item.Text = "0";
                item.SubItems.AddRange(new[] { FormTransactionEdit.Description, FormTransactionEdit.Diffrence.ToString() });
                listView.Items.Add(item); // Add the items
                CalculateSaldo();
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
        }

        private void gemSomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
    }
}
