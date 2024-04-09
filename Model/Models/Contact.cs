using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Contact
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;        
        public int dayPhone { get; set; }        
        public int eveningPhone { get; set; }
        public string address { get; set; } = string.Empty;
        public string namesList
        {
            get { return lastName + ", " + firstName; }
        }                 

    }
}
