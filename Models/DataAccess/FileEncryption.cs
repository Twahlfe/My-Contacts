using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Security.Cryptography;
using System.Text.Json;

namespace Models.DataAccess
{
    public class FileEncryption
    {
        /// <summary>
        /// Sets the aes encryption key to the hashed password
        /// Prepends the IV, and the length of the IV to a filestream
        /// then encrypts the filestream and writes it to a .encjson file
        /// </summary>
        /// <param name="Contacts"></param> the list of contacts to be encrypted and saved
        /// <param name="file"></param> the file path to save
        /// <param name="key"></param> the hashed password provided
        /// <returns>"bool variable"</returns> returns true if successfull
        public static bool SaveContacts(Contacts contacts, string file, byte[] key)
        {   
            
            Aes aes = Aes.Create();
            aes.Key = key;                        
            ICryptoTransform transform = aes.CreateEncryptor();

            int ivl = aes.IV.Length;
            byte[] ivLength = BitConverter.GetBytes(ivl);

            using (var encryptionfs = new FileStream(file, FileMode.Create))
            {
                
                encryptionfs.Write(ivLength, 0, 4);
                encryptionfs.Write(aes.IV, 0, ivl);            
                        
                using (var outStreamEncrypted = new CryptoStream(encryptionfs, transform, CryptoStreamMode.Write))
                {                                
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    JsonSerializer.Serialize(outStreamEncrypted, contacts, options);
                }
            }

            return true;

        }

        /// <summary>
        /// Opens the encrypted json file using the password provided
        /// Reads the aes.IV from the encrypted data
        /// </summary>
        /// <param name="filePath"></param>
        /// /// <param name="key"></param> the hashed password provided
        /// <returns></returns>
        public static Contacts OpenContacts(string filePath, byte[] key)
        {            
            Aes aes = Aes.Create();
            aes.Key = key;

            Contacts contacts;
                                    
            byte[] ivl = new byte[4];

            using var inStreamEncrypted = new FileStream(filePath, FileMode.Open);
                        
            inStreamEncrypted.Seek(0, SeekOrigin.Begin);
            inStreamEncrypted.Read(ivl, 0, 3);
                        
            int ivLength = BitConverter.ToInt32(ivl, 0);
            byte[] IV = new byte[ivLength];

            int startData = ivLength + 4;
            
            inStreamEncrypted.Seek(4, SeekOrigin.Begin);
            inStreamEncrypted.Read(IV, 0, ivLength);

            ICryptoTransform transform = aes.CreateDecryptor(key, IV);

            inStreamEncrypted.Seek(startData, SeekOrigin.Begin);
            using (var cryptoStream = new CryptoStream(inStreamEncrypted, transform, CryptoStreamMode.Read))
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                contacts = JsonSerializer.Deserialize<Contacts>(cryptoStream) ?? new Contacts();
            }

            return contacts ?? new Contacts();
        }

    }
}
