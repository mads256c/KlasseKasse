namespace Klassekasse
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "0",
            "Test",
            "0"}, -1);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.filerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.åbnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemSomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.afslutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderSaldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDiffrence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filerToolStripMenuItem,
            this.omToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(836, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // filerToolStripMenuItem
            // 
            this.filerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.åbnToolStripMenuItem,
            this.gemToolStripMenuItem,
            this.gemSomToolStripMenuItem,
            this.toolStripSeparator1,
            this.afslutToolStripMenuItem});
            this.filerToolStripMenuItem.Name = "filerToolStripMenuItem";
            this.filerToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.filerToolStripMenuItem.Text = "Filer";
            // 
            // åbnToolStripMenuItem
            // 
            this.åbnToolStripMenuItem.Name = "åbnToolStripMenuItem";
            this.åbnToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.åbnToolStripMenuItem.Text = "Åbn";
            // 
            // gemToolStripMenuItem
            // 
            this.gemToolStripMenuItem.Name = "gemToolStripMenuItem";
            this.gemToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.gemToolStripMenuItem.Text = "Gem";
            // 
            // gemSomToolStripMenuItem
            // 
            this.gemSomToolStripMenuItem.Name = "gemSomToolStripMenuItem";
            this.gemSomToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.gemSomToolStripMenuItem.Text = "Gem som";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // afslutToolStripMenuItem
            // 
            this.afslutToolStripMenuItem.Name = "afslutToolStripMenuItem";
            this.afslutToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.afslutToolStripMenuItem.Text = "Afslut";
            // 
            // omToolStripMenuItem
            // 
            this.omToolStripMenuItem.Name = "omToolStripMenuItem";
            this.omToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.omToolStripMenuItem.Text = "Om";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 475);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(836, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabelStatus.Text = "Status: OK";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSaldo,
            this.columnHeaderDescription,
            this.columnHeaderDiffrence});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView.Location = new System.Drawing.Point(13, 28);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(811, 408);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSaldo
            // 
            this.columnHeaderSaldo.Text = "Saldo";
            this.columnHeaderSaldo.Width = 70;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Beskrivelse";
            this.columnHeaderDescription.Width = 666;
            // 
            // columnHeaderDiffrence
            // 
            this.columnHeaderDiffrence.Text = "Forskel";
            this.columnHeaderDiffrence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderDiffrence.Width = 71;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(748, 443);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Tilføj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(667, 443);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Fjern";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(586, 443);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Ændre";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(13, 452);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(46, 13);
            this.labelSaldo.TabIndex = 6;
            this.labelSaldo.Text = "Saldo: 0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 497);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem åbnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gemSomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem afslutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderSaldo;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderDiffrence;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label labelSaldo;
    }
}

