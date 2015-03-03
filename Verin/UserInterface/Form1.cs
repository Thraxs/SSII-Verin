using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
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
        private static TimeManager timeManager;

        public Form1()
        {
            InitializeComponent();
            combo_language.SelectedIndex = 0;
            combo_periodicity.SelectedIndex = 0;
            combo_hashAlgorithm.SelectedIndex = 0;
            Threads.init(this);

            //Start time manager for periodic checks
            timeManager = new TimeManager();
            Thread thread = new Thread(timeManager.start);
            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop time manager when application is closed
            timeManager.stop();
        }

        //Change language
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

            foreach (Control c in this.groupBox1.Controls)
            {
                resources.ApplyResources(c, c.Name, language);
            }

            foreach (Control c in this.groupBox2.Controls)
            {
                resources.ApplyResources(c, c.Name, language);
            }

            columnHeader1.Text = resources.GetString("columnHeader1.Text", language);
            columnHeader2.Text = resources.GetString("columnHeader2.Text", language);
            columnHeader3.Text = resources.GetString("columnHeader3.Text", language);
            columnHeader4.Text = resources.GetString("columnHeader4.Text", language);

            refreshFileList();
        }

        //Add new folder
        private void button_add_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string path = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
                Folder folder = new Folder(path, (HashType)combo_hashAlgorithm.SelectedIndex, (Periodicity)combo_periodicity.SelectedIndex);
                list_folders.Items.Add(folder.path);
                folder.readFiles();
                Folders.add(folder);
                list_folders.SelectedIndex = list_folders.Items.Count - 1;
            }
        }

        //Delete existing folder
        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = list_folders.SelectedIndex;
            if (index == -1) return; //If no folder selected, exit

            string localizedTitle = new string[] { "Delete folder", "Borrar carpeta" }[currentLanguage];     //TODO: Better translation method
            string localizedMessage = new string[] { "Are you sure you want to delete the folder?", "¿Estas seguro de que quieres borrar la carpeta?" }[currentLanguage];     //TODO: Better translation method
            DialogResult dialogResult = MessageBox.Show(localizedMessage, localizedTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Folders.delete(index);
                list_folders.Items.RemoveAt(index);
                progressBar_hashing.Value = 0;

                //Clear file list
                listView1.Items.Clear();
            }
        }

        //Create a list view item with the file information
        private ListViewItem createListViewItem(File file)
        {
            Color rowColor;
            string status;
            switch (file.status)
            {
                case FileStatus.NEW:
                    rowColor = Color.White;
                    status = new string[] { "NEW", "NUEVO" }[currentLanguage];
                    break;
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
                case FileStatus.EXTRA:
                    rowColor = Color.LightBlue;
                    status = new string[] { "EXTRA", "EXTRA" }[currentLanguage];
                    break;
                default:
                    rowColor = Color.LightYellow;
                    status = new string[] { "MISMATCH", "DIFERENTE" }[currentLanguage];
                    break;
            }
            string[] data = new string[] { file.getName(), file.baseHash, file.latestHash, status };
            ListViewItem item = new ListViewItem(data);
            item.BackColor = rowColor;

            return item;
        }

        //Update an item in the list view and set the progress bar accordingly
        delegate void UpdateListViewItemCallBack(File file);
        internal void updateListViewItem(File file)
        {
            if (this.InvokeRequired)
            {
                UpdateListViewItemCallBack callback = new UpdateListViewItemCallBack(updateListViewItem);
                this.Invoke(callback, new object[] { file });
            }
            else
            {
                //Increase progress bar 
                this.stepProgressBar();

                int index = file.getFileIndex();
                ListViewItem item = createListViewItem(file);
                listView1.Items[file.getFileIndex()] = item;
            }

        }

        //Perform an step in the progress bar
        delegate void StepProgressBarCallBack();
        internal void stepProgressBar()
        {
            if (this.InvokeRequired)
            {
                StepProgressBarCallBack callback = new StepProgressBarCallBack(stepProgressBar);
                this.Invoke(callback, new object[] { });
            }
            else
            {
                progressBar_hashing.PerformStep();
            }
        }

        //Change selected folder
        private void list_folders_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFileList();
        }

        //Update current file list
        delegate void RefreshFileListCallBack();
        internal void refreshFileList()
        {
            if (this.InvokeRequired)
            {
                RefreshFileListCallBack callback = new RefreshFileListCallBack(refreshFileList);
                this.Invoke(callback, new object[] { });
            }
            else
            {
                int index = list_folders.SelectedIndex;
                if (index != -1)
                {
                    Folder folder = Folders.get(index);
                    textBox_hashAlgorithm.Text = folder.hashType.ToString();
                    textBox_periodicity.Text = combo_periodicity.Items[(int)folder.periodicity].ToString();
                    textBox_status.Text = folder.status.ToString();
                    button_computeHashes.Enabled = true;
                    button_remove.Enabled = true;

                    //List files
                    listView1.Items.Clear();
                    List<File> files = folder.files;
                    foreach (File file in files)
                    {
                        ListViewItem item = createListViewItem(file);
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    textBox_hashAlgorithm.Text = "";
                    textBox_periodicity.Text = "";
                    textBox_status.Text = "";
                    button_computeHashes.Enabled = false;
                    button_remove.Enabled = false;
                    listView1.Items.Clear();
                }
            }
        }

        //Compute hashes for current folder
        private void button_computeHashes_Click(object sender, EventArgs e)
        {
            Folder folder = Folders.get(list_folders.SelectedIndex);

            //Check for new files and then compute hashes
            folder.findNewFiles();
            listView1.Items.Clear();
            List<File> files = folder.files;
            foreach (File file in files)
            {
                ListViewItem item = createListViewItem(file);
                listView1.Items.Add(item);
            }

            progressBar_hashing.Maximum = folder.files.Count;
            progressBar_hashing.Value = 0;

            //Compute folder hashes
            folder.computeHashes(false);

            //If folder was deleted, clear window
            if (folder.status == FolderStatus.DELETED)
            {
                listView1.Items.Clear();
            }
        }

        private void button_browseLogs_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Logger.logPath))
            {
                Process.Start(Logger.logPath);
            }
            else
            {
                string localizedTitle = new string[] { "Error", "Error" }[currentLanguage];     //TODO: Better translation method
                string localizedMessage = new string[] { "No logs found in the system", "No existen logs en el sistema" }[currentLanguage];     //TODO: Better translation method
                DialogResult dialogResult = MessageBox.Show(localizedMessage, localizedTitle, MessageBoxButtons.OK);
            }
        }
    }
}