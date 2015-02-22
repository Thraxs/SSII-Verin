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
        public static int currentLanguage;

        public Form1()
        {
            InitializeComponent();
            combo_language.SelectedIndex = 0;
            combo_hashAlgorithm.SelectedIndex = 0;
        }

        private void combo_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] codes = new string[] { "en-US", "es-ES" };
            string code = codes[combo_language.SelectedIndex];
            currentLanguage = combo_language.SelectedIndex;

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
                showFiles(folder);
            }
        }

        private void showFiles(Folder folder)
        {
            List<File> files = folder.files;
            progressBar_hashing.Maximum = files.Count;
            progressBar_hashing.Value = 0;
            foreach (File file in files)
            {
                file.computeBaseHash();
                file.computeLatestHash();
                addFileRow(file);
            }
        }

        private void addFileRow(File file)
        {
            Color rowColor;
            String status;
            switch (file.status)
            {
                case FileStatus.GOOD:
                    rowColor = Color.LightGreen;
                    status = new string[] { "GOOD", "BUENO" }[currentLanguage];     //TODO: Better translation method
                    break;
                case FileStatus.MISMATCH:
                    rowColor = Color.LightYellow;
                    status = new string[] { "MISMATCH", "DIFERENTE" }[currentLanguage];
                    break;
                case FileStatus.DELETED:
                    rowColor = Color.Red;
                    status = new string[] { "DELETED", "BORRADO" }[currentLanguage];
                    break;
                case FileStatus.NEW:
                    rowColor = Color.LightBlue;
                    status = new string[] { "NEW", "Nuevo" }[currentLanguage];
                    break;
                default:
                    rowColor = Color.LightYellow;
                    status = new string[] { "MISMATCH", "DIFERENTE" }[currentLanguage];
                    break;
            }
            string[] data = new string[] { file.getName(), file.baseHash, file.latestHash, status };
            ListViewItem item = new ListViewItem(data);
            item.BackColor = rowColor;
            listView1.Items.Add(item);
        }
    }
}
