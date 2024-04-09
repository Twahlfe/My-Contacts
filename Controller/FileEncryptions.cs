using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataAccess;
using System.Security.Cryptography;
using Models.Models;
using System.Text.Json;

namespace Controller
{
    public class FileEncryptions
    {           
        /// <summary>
        /// Creates the encryption key by hashing the user password, then sends the data,
        /// the file path, and the password to the encryption method
        /// </summary>
        /// <param name="data"></param> 
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool SaveFile(Contacts data, string file, string password)
        {
            byte[] key = HashPassword(password);
            return FileEncryption.SaveContacts(data, file, key);
        }

        /// <summary>
        /// Sends the key provided by hashing the user password and the file path
        /// to be be read and decrypted, and returns a completed List<contacts>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <returns>List<contacts></returns>
        public static Contacts OpenFile(string file, string password)
        {
            byte[] key = HashPassword(password);
            return FileEncryption.OpenContacts(file, key);
        }

        /// <summary>
        /// Creates an encryption key based on a password the user provides
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] HashPassword(string password)
        {
            UnicodeEncoding ue = new();
            byte[] key = ue.GetBytes(password);
            SHA256 shHash = SHA256.Create();
            return shHash.ComputeHash(key);
        }
    }    

}

