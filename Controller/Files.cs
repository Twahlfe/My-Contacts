using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.DataAccess;
using Models;

namespace Controller
{
    public static class Files
    {
        /// <summary>
        /// Determines what type of unencrypted file the user would like to open
        /// and calls the appropriate class
        /// </summary>
        /// <param name="file"></param>
        /// <returns>null</returns>
        public static Contacts OpenFile(string file)
        {
            if (file.ToLower().EndsWith("dat"))
            {
                return BinaryFile.GetContacts(file);
            }
            if (file.ToLower().EndsWith("json"))
            {
                return JsonFile.GetContacts(file);
            }
            if (file.ToLower().EndsWith("xml"))
            {
                return XMLFile.GetContacts(file);
            }
            return null;
        }

        /// <summary>
        /// Determines what kind of unencrypted file the user would like to save as
        /// and calls the appropriate class
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool SaveFile(Contacts contacts, string file)
        {
            // Contacts contacts = new Contacts();
            // foreach (var n in data) contacts.Add((Contact)n);
                        
            if (file.ToLower().EndsWith("dat"))
            {
                return BinaryFile.SaveContacts(contacts, file);
            }
            if (file.ToLower().EndsWith("json"))
            {
                return JsonFile.SaveContacts(contacts, file);
            }
            if (file.ToLower().EndsWith("xml"))
            {
                return XMLFile.SaveContacts(contacts, file);
            }
            return false;
        }
    }
}
