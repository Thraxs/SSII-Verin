using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;

namespace Verin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            combo_language.SelectedIndex = 0;
            combo_hashAlgorithm.SelectedIndex = 0;
        }

        private void combo_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] codes = new string[] { "en", "es-ES" };
            string code = codes[combo_language.SelectedIndex];

            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            CultureInfo language = new CultureInfo(code);

            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, language);
            }

            columnHeader1.Text = resources.GetString("columnHeader1.Text", language);
            columnHeader2.Text = resources.GetString("columnHeader2.Text", language);
            columnHeader3.Text = resources.GetString("columnHeader3.Text", language);
            columnHeader4.Text = resources.GetString("columnHeader4.Text", language);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            String path = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
                Folder folder = new Folder(path, (HashType)combo_hashAlgorithm.SelectedIndex);
                list_folders.Items.Add(folder.path);
                folder.readFiles();
            }
        }
    }
}
