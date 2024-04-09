using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    /// <summary>
    /// The object type Contact that will be used to create the lists to be manipulated,
    /// saved, and read from files
    /// </summary>
    public class Contact_old
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        // public string dayPhone { get; set; } = string.Empty;
        public long dayPhone { get; set; }
        // public string eveningPhone { get; set; } = string.Empty;
        public long eveningPhone { get; set; }
        public string address { get; set; } = string.Empty;
        public string namesList
        {
            get { return lastName + ", " + firstName; }
        }

    }
}