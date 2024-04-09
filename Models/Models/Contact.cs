using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Models
{
    public partial class Contact
    {
        [Key]
        public int Count { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string? Email { get; set; }
        public long? DayPhone { get; set; }
        public long? EveningPhone { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }

        public string namesList
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}
