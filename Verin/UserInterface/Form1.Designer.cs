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
            this.button_remove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar_hashing = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_periodicity = new System.Windows.Forms.TextBox();
            this.textBox_hashAlgorithm = new System.Windows.Forms.TextBox();
            this.button_computeHashes = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_browseLogs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.combo_hashAlgorithm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_periodicity = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_language
            // 
            this.combo_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_language.FormattingEnabled = true;
            this.combo_language.Items.AddRange(new object[] {
            resources.GetString("combo_language.Items"),
            resources.GetString("combo_language.Items1")});
            resources.ApplyResources(this.combo_language, "combo_language");
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
            this.list_folders.FormattingEnabled = true;
            resources.ApplyResources(this.list_folders, "list_folders");
            this.list_folders.Name = "list_folders";
            this.list_folders.SelectedIndexChanged += new System.EventHandler(this.list_folders_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this.listView1, "listView1");
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
            // button_remove
            // 
            resources.ApplyResources(this.button_remove, "button_remove");
            this.button_remove.Name = "button_remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // progressBar_hashing
            // 
            resources.ApplyResources(this.progressBar_hashing, "progressBar_hashing");
            this.progressBar_hashing.Name = "progressBar_hashing";
            this.progressBar_hashing.Step = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_status);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_periodicity);
            this.groupBox1.Controls.Add(this.textBox_hashAlgorithm);
            this.groupBox1.Controls.Add(this.button_computeHashes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBox_status
            // 
            resources.ApplyResources(this.textBox_status, "textBox_status");
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // textBox_periodicity
            // 
            resources.ApplyResources(this.textBox_periodicity, "textBox_periodicity");
            this.textBox_periodicity.Name = "textBox_periodicity";
            this.textBox_periodicity.ReadOnly = true;
            // 
            // textBox_hashAlgorithm
            // 
            resources.ApplyResources(this.textBox_hashAlgorithm, "textBox_hashAlgorithm");
            this.textBox_hashAlgorithm.Name = "textBox_hashAlgorithm";
            this.textBox_hashAlgorithm.ReadOnly = true;
            // 
            // button_computeHashes
            // 
            resources.ApplyResources(this.button_computeHashes, "button_computeHashes");
            this.button_computeHashes.Name = "button_computeHashes";
            this.button_computeHashes.UseVisualStyleBackColor = true;
            this.button_computeHashes.Click += new System.EventHandler(this.button_computeHashes_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // button_browseLogs
            // 
            resources.ApplyResources(this.button_browseLogs, "button_browseLogs");
            this.button_browseLogs.Name = "button_browseLogs";
            this.button_browseLogs.UseVisualStyleBackColor = true;
            this.button_browseLogs.Click += new System.EventHandler(this.button_browseLogs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Controls.Add(this.combo_hashAlgorithm);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.combo_periodicity);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button_add
            // 
            resources.ApplyResources(this.button_add, "button_add");
            this.button_add.Name = "button_add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // combo_hashAlgorithm
            // 
            this.combo_hashAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_hashAlgorithm.FormattingEnabled = true;
            this.combo_hashAlgorithm.Items.AddRange(new object[] {
            resources.GetString("combo_hashAlgorithm.Items"),
            resources.GetString("combo_hashAlgorithm.Items1"),
            resources.GetString("combo_hashAlgorithm.Items2"),
            resources.GetString("combo_hashAlgorithm.Items3"),
            resources.GetString("combo_hashAlgorithm.Items4"),
            resources.GetString("combo_hashAlgorithm.Items5")});
            resources.ApplyResources(this.combo_hashAlgorithm, "combo_hashAlgorithm");
            this.combo_hashAlgorithm.Name = "combo_hashAlgorithm";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // combo_periodicity
            // 
            this.combo_periodicity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_periodicity.FormattingEnabled = true;
            this.combo_periodicity.Items.AddRange(new object[] {
            resources.GetString("combo_periodicity.Items"),
            resources.GetString("combo_periodicity.Items1"),
            resources.GetString("combo_periodicity.Items2"),
            resources.GetString("combo_periodicity.Items3"),
            resources.GetString("combo_periodicity.Items4"),
            resources.GetString("combo_periodicity.Items5"),
            resources.GetString("combo_periodicity.Items6")});
            resources.ApplyResources(this.combo_periodicity, "combo_periodicity");
            this.combo_periodicity.Name = "combo_periodicity";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar_hashing);
            this.Controls.Add(this.button_browseLogs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.list_folders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_language);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_language;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_folders;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox combo_hashAlgorithm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_periodicity;
        private System.Windows.Forms.TextBox textBox_periodicity;
        private System.Windows.Forms.TextBox textBox_hashAlgorithm;
        private System.Windows.Forms.Button button_browseLogs;
        private System.Windows.Forms.Button button_computeHashes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ProgressBar progressBar_hashing;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Label label8;






    }
}

