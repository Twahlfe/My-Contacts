using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Contacts : BindingList<Contact>
    {
        /// <summary>
        /// SearchContacts uses linq to search through the list of contacts and
        /// adds those to a searchResult list of type Contacts.
        /// </summary>
        /// <param name="searchBox"></param> this is the variable to be used in the query
        /// <returns>list of search results as a list of type Contact</returns>
        public Contacts SearchContacts(string searchBox)
        {
            //IEnumerable<Contact> query = from contact in this select contact;
            IEnumerable<Contact> query = from contact in this select contact;
            var searchContacts = new Contacts();

            if (!string.IsNullOrEmpty(searchBox))  // Make sure there is something to search
            {
                // First see if a number or string is being searched
                long searchNumber;
                bool success = long.TryParse(searchBox, out searchNumber);
                if (success == true)
                {
                    query = query.Where(contact => contact.DayPhone.Equals(searchNumber) ||
                            (contact.EveningPhone.Equals(searchNumber)));
                    foreach (var contact in query) searchContacts.Add(contact);
                }
                // If searchBox can't be converted to Int64, continue the query with searchBox as a string
                else
                {
                    query = query.Where(contact => contact.FirstName.ToLower().Contains(searchBox.ToLower()) ||
                            (contact.LastName.ToLower().Contains(searchBox.ToLower()) ||
                            contact.Email.ToLower().Contains(searchBox.ToLower()) ||
                            contact.Address.ToLower().Contains(searchBox.ToLower())));
                    foreach (var contact in query) searchContacts.Add(contact);
                }
            }
            
            return searchContacts;
        }
    }
}
