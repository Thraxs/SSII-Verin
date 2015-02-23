using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    public enum FolderStatus { GOOD, MISMATCH, DELETED };

    public enum HashType { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 };

    public enum Periodicity { NO, M5, M30, M60, H6, H12, H24 };

    class Folder
    {
        public string path { get; set; }
        public HashType hashType { get; set; }
        public Periodicity periodicity { get; set; }
        public List<File> files { get; set; }
        public FolderStatus status { get; set; }
        
        public Folder(string path, HashType hashType, Periodicity periodicity)
        {
            this.path = path;
            this.hashType = hashType;
            this.periodicity = periodicity;
            this.files = new List<File>();
            if (Directory.Exists(path))
            {
                this.status = FolderStatus.GOOD;
            }
            else
            {
                this.status = FolderStatus.DELETED;
            }
        }

        public void readFiles()
        {
            string[] directoryFiles = Directory.GetFiles(path);
            foreach (string file in directoryFiles)
            {
                this.files.Add(new File(file, this));
            }
        }

        public void computeBaseHashes()
        {
            foreach (File file in files)
            {
                file.computeBaseHash();
            }
        }

        public void computeLatestHashes()
        {
            if (Directory.Exists(path))
            {
                foreach (File file in files)
                {
                    file.computeLatestHash();

                    if (!file.getIntegrity())
                    {
                        this.status = FolderStatus.MISMATCH;
                    }
                }
            }
            else
            {
                this.status = FolderStatus.DELETED;
            }
        }
    }
}
