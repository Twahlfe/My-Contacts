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
        public static List<Contact> GetContacts(string filePath)
        {
            // Create the list of the contact class
            List<Contact> contacts = new List<Contact>();
                      

            // Open the binary input stream
            using BinaryReader binaryIn =
                new BinaryReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

            // Read each item in the contact list until the end of the file
            while (binaryIn.PeekChar() != -1)
            {
                Contact contact = new Contact();
                contact.firstName = binaryIn.ReadString();
                contact.lastName = binaryIn.ReadString();
                contact.email = binaryIn.ReadString();
                contact.dayPhone = binaryIn.ReadInt32();
                contact.eveningPhone = binaryIn.ReadInt32();
                contact.address = binaryIn.ReadString();
                contacts.Add(contact);
            }
            
            return contacts;
        }


        public static bool SaveContacts(List<Contact> contacts, string filePath)
        {            
            // Open the binary output stream            
            using BinaryWriter binaryOut =
                new BinaryWriter(
                new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write));

            //  Write each item in the contact class
            foreach (Contact contact in contacts)
            {
                binaryOut.Write(contact.firstName);
                binaryOut.Write(contact.lastName);
                binaryOut.Write(contact.email);
                binaryOut.Write(contact.dayPhone);
                binaryOut.Write(contact.eveningPhone);
                binaryOut.Write(contact.address);                
            }

            
            return true;
        }
        
    }
}
