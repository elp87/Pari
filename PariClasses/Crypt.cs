using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PariClasses
{
    public static class Crypt
    {
        private static byte[] key = new byte[] { 20, 48, 12, 36, 64, 134, 104, 47 };
        private static byte[] IV = new byte[] { 98, 142, 213, 66, 144, 6, 41, 143 };

        public static void EncryptFile(string inFilePath, string outFilePath, EncryptDirection direct)
        {
            FileStream fin = new FileStream(inFilePath, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fin.Length;
            int len;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            CryptoStream encStream;
            if (direct == EncryptDirection.Encryption) { encStream = new CryptoStream(fout, des.CreateEncryptor(key, IV), CryptoStreamMode.Write); }
            else { encStream = new CryptoStream(fout, des.CreateDecryptor(key, IV), CryptoStreamMode.Write); }
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
        public enum EncryptDirection
        {
            Encryption,
            Decription
        }
    }
}
