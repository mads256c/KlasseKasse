using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

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
            int Saldo = 0;
            foreach (ListViewItem item in listView.Items)
            {
                item.UseItemStyleForSubItems = false;
                Saldo += int.Parse(item.SubItems[2].Text);
                item.Text = Saldo.ToString();

                if (Saldo < 0)
                {
                    item.SubItems[0].ForeColor = Color.Red;
                }
                else
                {
                    item.SubItems[0].ForeColor = SystemColors.ControlText;
                }

                if (int.Parse(item.SubItems[2].Text) < 0)
                {
                    item.SubItems[2].ForeColor = Color.Red;
                }
                else
                {
                    item.SubItems[2].ForeColor = SystemColors.ControlText;
                }

            }

            labelSaldo.Text = $"Saldo: {Saldo}";
        }

        /// <summary>
        /// Applies the edits from FormTransactionEdit
        /// </summary>
        private void ApplyEdits()
        {
            if (FormTransactionEdit.Description != null && FormTransactionEdit.Diffrence != null)
            {
                listView.SelectedItems[0].SubItems[1].Text = FormTransactionEdit.Description;
                listView.SelectedItems[0].SubItems[2].Text = FormTransactionEdit.Diffrence.ToString();
            }
            CalculateSaldo();
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
                new FormTransactionEdit(listView.SelectedItems[0].SubItems[1].Text, int.Parse(listView.SelectedItems[0].SubItems[2].Text)).ShowDialog(); // This function blocks this thread, so we have the values when we are done.
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
                }
            }
            else
            {
                MessageBox.Show("Makér en række."); //Tell the user to only select one row.
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Ask the user about row information
            new FormTransactionEdit(null, null).ShowDialog(); // This function blocks this thread, so we have the values when we are done.

            //Return if one of the values are null
            if (FormTransactionEdit.Description != null && FormTransactionEdit.Diffrence != null)
            {
                //Create a new ListViewItem
                ListViewItem item = new ListViewItem();
                item.Text = "0";
                item.SubItems.AddRange(new string[] { FormTransactionEdit.Description, FormTransactionEdit.Diffrence.ToString() });
                listView.Items.Add(item); // Add the items
                CalculateSaldo();
            }
        }
    }
}
