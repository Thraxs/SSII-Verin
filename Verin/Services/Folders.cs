using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    static class Folders
    {
        private static List<Folder> folders = new List<Folder>();

        public static void add(Folder folder)
        {
            folders.Add(folder);
        }

        public static List<Folder> get()
        {
            return folders;
        }

        public static Folder get(int index)
        {
            return folders[index];
        }

        public static void delete(int index)
        {
            folders.RemoveAt(index);
        }
    }
}
