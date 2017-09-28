using System.ComponentModel;
using System.Windows.Forms;

namespace Klassekasse
{
    partial class FormTransactionEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDifference = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonDeposit = new System.Windows.Forms.RadioButton();
            this.radioButtonPayment = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ind/Udbetaling:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Beskrivelse:";
            // 
            // textBoxDifference
            // 
            this.textBoxDifference.Location = new System.Drawing.Point(16, 27);
            this.textBoxDifference.Name = "textBoxDifference";
            this.textBoxDifference.Size = new System.Drawing.Size(173, 20);
            this.textBoxDifference.TabIndex = 2;
            this.textBoxDifference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDifference_KeyDown);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(16, 80);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(256, 140);
            this.textBoxDescription.TabIndex = 3;
            this.textBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDescription_KeyDown);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(197, 226);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(116, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuller";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // radioButtonDeposit
            // 
            this.radioButtonDeposit.AutoSize = true;
            this.radioButtonDeposit.Checked = true;
            this.radioButtonDeposit.Location = new System.Drawing.Point(195, 13);
            this.radioButtonDeposit.Name = "radioButtonDeposit";
            this.radioButtonDeposit.Size = new System.Drawing.Size(77, 17);
            this.radioButtonDeposit.TabIndex = 6;
            this.radioButtonDeposit.TabStop = true;
            this.radioButtonDeposit.Text = "Indbetaling";
            this.radioButtonDeposit.UseVisualStyleBackColor = true;
            // 
            // radioButtonPayment
            // 
            this.radioButtonPayment.AutoSize = true;
            this.radioButtonPayment.Location = new System.Drawing.Point(195, 36);
            this.radioButtonPayment.Name = "radioButtonPayment";
            this.radioButtonPayment.Size = new System.Drawing.Size(76, 17);
            this.radioButtonPayment.TabIndex = 7;
            this.radioButtonPayment.TabStop = true;
            this.radioButtonPayment.Text = "Udbetaling";
            this.radioButtonPayment.UseVisualStyleBackColor = true;
            // 
            // FormTransactionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.radioButtonPayment);
            this.Controls.Add(this.radioButtonDeposit);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxDifference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTransactionEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tilføjning eller ændring";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxDifference;
        private TextBox textBoxDescription;
        private Button buttonOk;
        private Button buttonCancel;
        private RadioButton radioButtonDeposit;
        private RadioButton radioButtonPayment;
    }
}