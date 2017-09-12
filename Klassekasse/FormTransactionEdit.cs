using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klassekasse
{
    public partial class FormTransactionEdit : Form
    {
        public static string Description;
        public static int? Diffrence;

        public FormTransactionEdit(string description, int? diffrence)
        {
            InitializeComponent();
            Description = null;
            Diffrence = null;
            if (description != null && diffrence != null)
            {
                textBoxDescription.Text = description;
                textBoxDiffrence.Text = diffrence.ToString();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxDiffrence.Text, out int result))
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
    }
}
