using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    static class Cryptography
    {
        public static string getHash(FileStream stream, HashType hashType)
        {
            string hexHash;

            switch (hashType)
            {
                case HashType.MD5:
                    hexHash = getMD5Hash(stream);
                    break;
                case HashType.RIPEMD160:
                    hexHash = getRIPEMD160Hash(stream);
                    break;
                case HashType.SHA1:
                    hexHash = getSHA1Hash(stream);
                    break;
                case HashType.SHA256:
                    hexHash = getSHA256Hash(stream);
                    break;
                case HashType.SHA384:
                    hexHash = getSHA384Hash(stream);
                    break;
                case HashType.SHA512:
                    hexHash = getSHA512Hash(stream);
                    break;
                default:
                    hexHash = getMD5Hash(stream);
                    break;
            }

            return hexHash;
        }

        public static int getHashLength(HashType hashType)
        {
            int length = 0;

            switch (hashType)
            {
                case HashType.MD5:
                    length = 32;
                    break;
                case HashType.RIPEMD160:
                    length = 40;
                    break;
                case HashType.SHA1:
                    length = 40;
                    break;
                case HashType.SHA256:
                    length = 64;
                    break;
                case HashType.SHA384:
                    length = 96;
                    break;
                case HashType.SHA512:
                    length = 128;
                    break;
                default:
                    length = 32;
                    break;
            }

            return length;
        } 

        private static string getMD5Hash(FileStream stream)
        {
            string hexHash;

            using (MD5 md5hash = MD5.Create())
            {
                byte[] rawHash = md5hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string getRIPEMD160Hash(FileStream stream)
        {
            string hexHash;

            using (RIPEMD160 ripemd160hash = RIPEMD160.Create())
            {
                byte[] rawHash = ripemd160hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string getSHA1Hash(FileStream stream)
        {
            string hexHash;

            using (SHA1 sha1hash = SHA1.Create())
            {
                byte[] rawHash = sha1hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string getSHA256Hash(FileStream stream)
        {
            string hexHash;

            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] rawHash = sha256hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string getSHA384Hash(FileStream stream)
        {
            string hexHash;

            using (SHA384 sha384hash = SHA384.Create())
            {
                byte[] rawHash = sha384hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string getSHA512Hash(FileStream stream)
        {
            string hexHash;

            using (SHA512 sha512hash = SHA512.Create())
            {
                byte[] rawHash = sha512hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static string hashToString(byte[] rawHash)
        {
            StringBuilder stringbuilder = new StringBuilder();

            for (int i = 0; i < rawHash.Length; i++)
            {
                stringbuilder.Append(rawHash[i].ToString("x2"));
            }
            return stringbuilder.ToString();
        }
    }
}
