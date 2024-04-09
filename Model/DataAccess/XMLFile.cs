using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Models.DataAccess
{
    public class XMLFile
    {
        public static List<Contact> GetContacts(string filePath)
        {
            // Create the filestream
            using FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Contact>));

            List<Contact>? contacts = (List<Contact>?)xmlSerializer.Deserialize(fStream);

            return contacts ?? new List<Contact>();

        }

        public static bool SaveContacts(IList<Contact> contacts, string filePath)
        {
            using FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Contact>));

            mySerializer.Serialize(fStream, contacts);

            return true;
        }
    }
}
