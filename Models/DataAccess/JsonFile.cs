using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Models.Models;
using System.IO;
using System.Xml.Serialization;

namespace Models.DataAccess
{
    public class JsonFile
    {
        /// <summary>
        /// Populates a list of Contact read from a json file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List<Contact></returns>
        public static Contacts GetContacts(string filePath)
        {            
            using FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            Contacts contacts = JsonSerializer.Deserialize<Contacts>(fStream) ?? new Contacts();
            
            return contacts;

        }
        
        /// <summary>
        /// Sends a list of data <Contact> to a json text file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        /// <returns>true if successfull</returns>
        public static bool SaveContacts(Contacts contacts, string filePath)
        {            
            using FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            JsonSerializer.Serialize(fStream, contacts, options);

            return true;
        }
        
    }
}
