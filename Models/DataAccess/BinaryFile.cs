using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models.Models;
using System.IO;

namespace Models.DataAccess
{
    public class BinaryFile
    {
        /// <summary>
        /// Populates a list of Contact read from a binary file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>list of type Contact</returns>
        public static Contacts GetContacts(string filePath)
        {
            // Create the list of the Contacts class
            Contacts contacts = new();

            // Open the binary input stream
            using BinaryReader binaryIn =
                new BinaryReader(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read));

            // Read each item in the contact list until the end of the file
            while (binaryIn.PeekChar() != -1)
            {
                Contact contact = new Contact();
                contact.FirstName = binaryIn.ReadString();
                contact.LastName = binaryIn.ReadString();
                contact.Email = binaryIn.ReadString();
                // long r = binaryIn.ReadInt64();
                // if (r == 0) contact.DayPhone = null;
                contact.DayPhone = binaryIn.ReadInt64();
                // r = binaryIn.ReadInt64();
                // if (r == 0) contact.EveningPhone = null;
                contact.EveningPhone = binaryIn.ReadInt64();
                contact.Address = binaryIn.ReadString();
                contacts.Add(contact);
            }
            
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
            
            using BinaryWriter binaryOut =
                new BinaryWriter(
                new FileStream(filePath, FileMode.Create, FileAccess.Write));
                        
            foreach (Contact contact in contacts)
            {
                binaryOut.Write(contact.FirstName);
                binaryOut.Write(contact.LastName);
                binaryOut.Write(contact.Email ?? "");
                binaryOut.Write(contact.DayPhone ?? 0L);
                binaryOut.Write(contact.EveningPhone ?? 0L);
                binaryOut.Write(contact.Address ?? "");                
            }
            
            return true;
        }
        
    }
}
