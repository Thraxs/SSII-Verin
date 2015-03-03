using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    public enum FolderStatus { NEW, GOOD, MISMATCH, DELETED };

    public enum HashType { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 };

    public enum Periodicity { NO, M5, M30, M60, H6, H12, H24 };

    class Folder
    {
        public string path { get; set; }
        public HashType hashType { get; set; }
        public Periodicity periodicity { get; set; }
        public List<File> files { get; set; }
        public FolderStatus status { get; set; }
        public DateTime lastHash { get; set; }
        public int hashingProgress { get; set; }
        public bool hashingFinished { get; set; }
        
        public Folder(string path, HashType hashType, Periodicity periodicity)
        {
            this.path = path;
            this.hashType = hashType;
            this.periodicity = periodicity;
            this.files = new List<File>();
            this.hashingFinished = false;
            if (Directory.Exists(path))
            {
                this.status = FolderStatus.NEW;
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

        public void findNewFiles()
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            string[] directoryFiles = Directory.GetFiles(path);
            foreach (string file in directoryFiles)
            {
                File f = new File(file, this);
                if (!files.Contains(f))
                {
                    f.status = FileStatus.EXTRA;
                    files.Add(f);
                }
            }
        }

        public void computeHashes(bool background)
        {
            //Initialize hashing counter
            this.hashingProgress = 0;
            this.hashingFinished = false;

            if (Directory.Exists(path))
            {
                //Remove deleted extra files
                List<File> removed = new List<File>();
                foreach (File file in files)
                {
                    if (file.status == FileStatus.EXTRA && !(System.IO.File.Exists(file.path)))
                    {
                        removed.Add(file);

                        //Update progress bar for deleted file
                        Threads.form.stepProgressBar();
                    }
                }
                this.files = files.Except(removed).ToList<File>();

                TaskType taskType;
                if (this.status == FolderStatus.NEW)
                {
                    //If status is new, compute base hashes
                    taskType = TaskType.BASEHASH;
                }
                else
                {
                    //If not new, compute latest hashes
                    taskType = TaskType.LATESTHASH;
                }

                //Add tasks for each file
                this.status = FolderStatus.GOOD;
                foreach (File file in this.files)
                {
                    Threads.addTask(file, taskType, background);
                }
            }
            else
            {
                this.status = FolderStatus.DELETED;
                Logger.writeFolderLog(this);
            }
        }

        public int getFileIndex(File file)
        {
            int index = -1;
            index = files.IndexOf(file);
            return index;
        }

        public int getPeriodicityInMinutes()
        {
            int time = 0;

            switch (periodicity)
            {
                case Periodicity.M5:
                    time = 5;
                    break;
                case Periodicity.M30:
                    time = 30;
                    break;
                case Periodicity.M60:
                    time = 60;
                    break;
                case Periodicity.H6:
                    time = 360;
                    break;
                case Periodicity.H12:
                    time = 720;
                    break;
                case Periodicity.H24:
                    time = 1440;
                    break;
                default:
                    break;
            }

            return time;
        }
    }
}
