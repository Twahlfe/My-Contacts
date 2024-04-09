using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Models.Models;

namespace Models.DataAccess
{
    public class XMLFile
    {
        /// <summary>
        /// Populates a list of type Contact read from a json file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of Contact</returns>
        public static Contacts GetContacts(string filePath)
        {
            // Create the filestream
            using FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Contacts));

            Contacts contacts = (Contacts?)xmlSerializer.Deserialize(fStream) ?? new Contacts();

            return contacts;

        }

        /// <summary>
        /// Sends a list of type Contact and saves it to a binary file
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="filePath"></param>
        /// <returns>true if successfull</returns>
        public static bool SaveContacts(Contacts contacts, string filePath)
        {
            using FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            XmlSerializer mySerializer = new XmlSerializer(typeof(Contacts));

            mySerializer.Serialize(fStream, contacts);

            return true;
        }
    }
}
