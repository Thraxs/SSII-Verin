using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    public enum FileStatus { GOOD, MISMATCH, DELETED, NEW };

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
            this.status = FileStatus.GOOD;
        }

        public string getName()
        {
            return Path.GetFileName(path);
        }

        public void computeBaseHash()
        {
            if (System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.OpenRead(path);
                this.baseHash = Cryptography.getHash(stream, folder.hashType);
                stream.Close();
            }
            else
            {
                this.status = FileStatus.DELETED;
            }
        }

        public void computeLatestHash()
        {
            if (System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.OpenRead(path);
                this.latestHash = Cryptography.getHash(stream, folder.hashType);
                stream.Close();

                if (baseHash.Equals(latestHash))
                {
                    this.status = FileStatus.GOOD;
                }
                else
                {
                    this.status = FileStatus.MISMATCH;
                }
            }
            else
            {
                this.status = FileStatus.DELETED;
            }
        }

        public bool getIntegrity()
        {
            return this.baseHash.Equals(this.latestHash);
        }
    }
}
