using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verin
{
    public enum FileStatus { NEW, GOOD, MISMATCH, DELETED, EXTRA, REMOVED };

    class File
    {
        public Folder folder { get; set; }
        public string path { get; set; }
        public string baseHash { get; set; }
        public string latestHash { get; set; }
        public FileStatus status { get; set; }

        public File(string path, Folder folder)
        {
            this.path = path;
            this.folder = folder;
            this.status = FileStatus.NEW;
        }

        public string getName()
        {
            return Path.GetFileName(path);
        }

        public void computeBaseHash()
        {
            if (System.IO.File.Exists(path))
            {
                //If file is an extra, dont compute hash
                if (this.status == FileStatus.EXTRA)
                {
                    folder.status = FolderStatus.MISMATCH;
                    return;
                }

                try
                {
                    FileStream stream = System.IO.File.OpenRead(path);
                    this.baseHash = Cryptography.getHash(stream, folder.hashType);
                    stream.Close();
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("A file was being accessed by another process", "Exception", MessageBoxButtons.OK);
                }
            }
            else
            {
                //If file was an extra and is now removed, remove from folder
                if (this.status == FileStatus.EXTRA)
                {
                    this.status = FileStatus.REMOVED;
                    this.folder.files.Remove(this);
                    return;
                }

                this.status = FileStatus.DELETED;
            }

            //Increase folder hashing progress
            this.folder.hashingProgress++;
        }

        public void computeLatestHash()
        {
            if (System.IO.File.Exists(path))
            {
                //If file is an extra, dont compute hash
                if (this.status == FileStatus.EXTRA)
                {
                    folder.status = FolderStatus.MISMATCH;
                    this.folder.hashingProgress++;
                    return;
                }

                try
                {
                    FileStream stream = System.IO.File.OpenRead(path);
                    this.latestHash = Cryptography.getHash(stream, folder.hashType);
                    stream.Close();
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("A file was being accessed by another process", "Exception", MessageBoxButtons.OK);
                }

                if (baseHash.Equals(latestHash))
                {
                    this.status = FileStatus.GOOD;
                }
                else
                {
                    this.status = FileStatus.MISMATCH;
                    if (this.folder.status != FolderStatus.MISMATCH)
                    {
                        this.folder.status = FolderStatus.MISMATCH;
                    }
                }
            }
            else
            {
                //If file was an extra and is now removed, remove from folder
                if (this.status == FileStatus.EXTRA)
                {
                    this.status = FileStatus.REMOVED;
                    this.folder.files.Remove(this);
                    return;
                }

                this.status = FileStatus.DELETED;
                this.latestHash = "";
                if (this.folder.status != FolderStatus.MISMATCH)
                {
                    this.folder.status = FolderStatus.MISMATCH;
                }
            }

            //Increase folder hashing progress
            this.folder.hashingProgress++;
        }

        public int getFileIndex()
        {
            return this.folder.getFileIndex(this);
        }

        public bool isLastFileToHash()
        {
            Console.WriteLine("islast?..." + (this.folder.hashingProgress == this.folder.files.Count));
            return this.folder.hashingProgress == this.folder.files.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            File file = obj as File;
            if ((System.Object)file == null)
            {
                return false;
            }

            return (path == file.path) && (folder == file.folder);
        }

        public bool Equals(File file)
        {
            if ((object)file == null)
            {
                return false;
            }

            return (path == file.path) && (folder == file.folder);
        }

        public override int GetHashCode()
        {
            int hash = (13 * 7) * path.GetHashCode() * folder.GetHashCode();
            return hash;
        }
    }
}
