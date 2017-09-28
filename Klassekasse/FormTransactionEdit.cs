using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Klassekasse
{
    public struct TransactionData
    {
        public TransactionData(string description, decimal difference)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Difference = difference;
        }

        public string Description;
        public decimal Difference;
    }

    public partial class FormTransactionEdit : Form
    {
        /// <summary>
        /// Used to mask certan keys from the difference textbox.
        /// TODO: A better solution should be worked out. LOW PRIORITY
        /// </summary>
        public static readonly Keys[] Acceptedkeys = {
            Keys.D0, Keys.NumPad0, Keys.D1, Keys.NumPad1, Keys.D2, Keys.NumPad2, Keys.D3, Keys.NumPad3, Keys.D4, Keys.NumPad4, Keys.D5, Keys.NumPad5,
            Keys.D6, Keys.NumPad6, Keys.D7, Keys.NumPad7, Keys.D8, Keys.NumPad8, Keys.D9, Keys.NumPad9, Keys.OemMinus, Keys.Decimal, Keys.Oemcomma,
            Keys.OemPeriod, Keys.Back, Keys.Delete, Keys.Up, Keys.Down, Keys.Left, Keys.Right
        };

        //We store the value of the two textboxes here
        public TransactionData TransactionData;

        /// <inheritdoc />
        /// <summary>
        /// Use this when you dont want to preinitialize the textboxes on the form.
        /// </summary>
        public FormTransactionEdit()
        {
            InitializeComponent();
            Text = "Tilføjning";
        }

        /// <inheritdoc />
        /// <summary>
        /// Use this when you want to preinitialize the textboxes on the form.
        /// </summary>
        /// <param name="description">The description in the listview row</param>
        /// <param name="difference">The difference in the listview row</param>
        public FormTransactionEdit(string description, decimal difference)
        {
            InitializeComponent();
            textBoxDescription.Text = description;
            textBoxDifference.Text = difference.ToString(CultureInfo.CurrentCulture);
            Text = $"Ændring af {description}";
        }

        /// <summary>
        /// Fired when the user press the OK button
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                MessageBox.Show("Beskrivelsen kan ikke være tom.");
            }
            //Windows likes to change what the decimal seperator charactor is, so here is a hacky way to standardize it to the current locale.
            if (decimal.TryParse(textBoxDifference.Text.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)), out decimal result))
            {
                TransactionData = new TransactionData(textBoxDescription.Text, result);
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }

        /// <summary>
        /// Fired when the user press the Cancel button
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Fires when the user press a key inside the description textbox
        /// </summary>
        private void textBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            //Dont allow newlines. It would fuck op the whole save format.
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Fires when the user press a key inside the difference textbox
        /// </summary>
        private void textBoxDifference_KeyDown(object sender, KeyEventArgs e)
        {
            if (Acceptedkeys.Any(key => e.KeyCode == key)) return;
            e.SuppressKeyPress = true;
        }
    }
}
