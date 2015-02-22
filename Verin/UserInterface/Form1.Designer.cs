namespace Verin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.combo_language = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list_folders = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_hashAlgorithm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combo_language
            // 
            resources.ApplyResources(this.combo_language, "combo_language");
            this.combo_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_language.FormattingEnabled = true;
            this.combo_language.Items.AddRange(new object[] {
            resources.GetString("combo_language.Items"),
            resources.GetString("combo_language.Items1")});
            this.combo_language.Name = "combo_language";
            this.combo_language.SelectedIndexChanged += new System.EventHandler(this.combo_language_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // list_folders
            // 
            resources.ApplyResources(this.list_folders, "list_folders");
            this.list_folders.FormattingEnabled = true;
            this.list_folders.Name = "list_folders";
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button_add
            // 
            resources.ApplyResources(this.button_add, "button_add");
            this.button_add.Name = "button_add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_remove
            // 
            resources.ApplyResources(this.button_remove, "button_remove");
            this.button_remove.Name = "button_remove";
            this.button_remove.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // combo_hashAlgorithm
            // 
            resources.ApplyResources(this.combo_hashAlgorithm, "combo_hashAlgorithm");
            this.combo_hashAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_hashAlgorithm.FormattingEnabled = true;
            this.combo_hashAlgorithm.Items.AddRange(new object[] {
            resources.GetString("combo_hashAlgorithm.Items"),
            resources.GetString("combo_hashAlgorithm.Items1"),
            resources.GetString("combo_hashAlgorithm.Items2"),
            resources.GetString("combo_hashAlgorithm.Items3"),
            resources.GetString("combo_hashAlgorithm.Items4"),
            resources.GetString("combo_hashAlgorithm.Items5")});
            this.combo_hashAlgorithm.Name = "combo_hashAlgorithm";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combo_hashAlgorithm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.list_folders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_language);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_language;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_folders;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_hashAlgorithm;






    }
}

