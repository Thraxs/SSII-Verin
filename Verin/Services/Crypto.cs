using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verin
{
    static class Crypto
    {
        public static String getHash(FileStream stream, HashType hashType)
        {
            String hexHash;

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

        private static String getMD5Hash(FileStream stream)
        {
            String hexHash;

            using (MD5 md5hash = MD5.Create())
            {
                byte[] rawHash = md5hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String getRIPEMD160Hash(FileStream stream)
        {
            String hexHash;

            using (RIPEMD160 ripemd160hash = RIPEMD160.Create())
            {
                byte[] rawHash = ripemd160hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String getSHA1Hash(FileStream stream)
        {
            String hexHash;

            using (SHA1 sha1hash = SHA1.Create())
            {
                byte[] rawHash = sha1hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String getSHA256Hash(FileStream stream)
        {
            String hexHash;

            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] rawHash = sha256hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String getSHA384Hash(FileStream stream)
        {
            String hexHash;

            using (SHA384 sha384hash = SHA384.Create())
            {
                byte[] rawHash = sha384hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String getSHA512Hash(FileStream stream)
        {
            String hexHash;

            using (SHA512 sha512hash = SHA512.Create())
            {
                byte[] rawHash = sha512hash.ComputeHash(stream);

                hexHash = hashToString(rawHash);
            }

            return hexHash;
        }

        private static String hashToString(byte[] rawHash)
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
