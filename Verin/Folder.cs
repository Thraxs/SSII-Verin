using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    class Folder
    {
        public enum HashType { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 };
        private String name;
        private String path;
        private HashType hashType;

        public Folder(String name, String path, HashType hashType)
        {
            this.name = name;
            this.path = path;
            this.hashType = hashType;
        }

        public void computeHashes()
        {

        }
    }
}
