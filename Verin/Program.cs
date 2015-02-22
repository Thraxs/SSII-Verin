using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Verin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
            FileStream fs = File.OpenRead("C:\\Users\\Javier\\Downloads\\PersonImpl.java");
            Console.WriteLine(Crypto.getHash(fs, HashType.MD5));
            //Console.WriteLine(Crypto.getHash("Hello world"));
        }
    }
}
