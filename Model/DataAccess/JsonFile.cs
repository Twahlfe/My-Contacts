using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;

namespace Models.DataAccess
{
    public class JsonFile
    {

        public static List<Contact> GetContacts(string filePath)
        {
            // Create the filestream
            using FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            List<Contact>? contacts = JsonSerializer.Deserialize<List<Contact>>(fStream);

            return contacts ?? new List<Contact>();

        }

        public static bool SaveContacts(Object data, string filePath)
        {
            // Create the filestream
            using FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            JsonSerializer.Serialize(fStream, data, options);

            return true;
        }

        
    }
}
