using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    class Folder
    {
        public string path { get; set; }
        public HashType hashType { get; set; }
        public List<File> files { get; set; }
        public FolderStatus status { get; set; }
        
        public Folder(string path, HashType hashType)
        {
            this.path = path;
            this.hashType = hashType;
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
