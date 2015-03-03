using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    static class Logger
    {
        public static string logPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Verin";

        public static void writeFolderLog(Folder folder)
        {
            string fileName = folder.path;
            fileName = fileName.Replace(":", "");

            string date = DateTime.Now.ToString();
            fileName += ("_" + date + ".txt");
            fileName = fileName.Replace("/", "_");
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "_");
            fileName = fileName.Replace("\\", "_");

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            StreamWriter writer = new StreamWriter(logPath + "\\" + fileName);

            //If the folder has been deleted, write folder deleted log
            if (folder.status == FolderStatus.DELETED)
            {
                writer.WriteLine("Log date: " + date);
                writer.WriteLine("Folder path: " + folder.path);
                writer.WriteLine("Folder status: " + folder.status);

                writer.Close();
                return;
            }

            //Get max file name length to display data nicely
            int maxFileLength = maxFileNameLength(folder);

            //Init parameters for counting files
            int newFiles = 0;
            int goodFiles = 0;
            int mismatchedFiles = 0;
            int deletedFiles = 0;
            int extraFiles = 0;

            //Add file to count
            foreach (File file in folder.files)
            {
                switch (file.status)
                {
                    case FileStatus.NEW:
                        newFiles++;
                        break;
                    case FileStatus.GOOD:
                        goodFiles++;
                        break;
                    case FileStatus.MISMATCH:
                        mismatchedFiles++;
                        break;
                    case FileStatus.DELETED:
                        deletedFiles++;
                        break;
                    case FileStatus.EXTRA:
                        extraFiles++;
                        break;
                }

                string line = file.getName();
                line = line.PadRight(maxFileLength, ' ');
                line += " " + file.baseHash + " " + file.latestHash;
                line = line.PadRight(maxFileLength + 2 + (2*Cryptography.getHashLength(folder.hashType)));
                line += " " + file.status;
                writer.WriteLine(line);
            }

            writer.WriteLine("\n-----------------------------\n");
            writer.WriteLine("Log date: " + date);
            writer.WriteLine("Folder path: " + folder.path);
            writer.WriteLine("Folder status: " + folder.status);
            writer.WriteLine("New files: " + newFiles);
            writer.WriteLine("Good files: " + goodFiles);
            writer.WriteLine("Mismatched files: " + mismatchedFiles);
            writer.WriteLine("Deleted files: " + deletedFiles);
            writer.WriteLine("Extra files: " + extraFiles);

            writer.Close();
        }

        //Find the maximum length of all file names of the folder
        private static int maxFileNameLength(Folder folder)
        {
            int maxLength = 0;

            foreach (var item in folder.files)
            {
                int nameLength = item.getName().Length;
                if (nameLength > maxLength)
                {
                    maxLength = nameLength;
                }
            }

            return maxLength;
        }
    }
}
