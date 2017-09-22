﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klassekasse
{
    public partial class FormTransactionEdit : Form
    {
        public static string Description;
        public static double? Diffrence;

        public FormTransactionEdit()
        {
            InitializeComponent();
            Description = null;
            Diffrence = null;
        }

        public FormTransactionEdit(string description, double? diffrence)
        {
            InitializeComponent();
            Description = null;
            Diffrence = null;
            textBoxDescription.Text = description;
            textBoxDiffrence.Text = diffrence.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxDiffrence.Text.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)), out double result))
            {
                Description = textBoxDescription.Text;
                Diffrence = result;
                this.Close();
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Description = null;
            Diffrence = null;
            this.Close();
        }

        private void textBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
