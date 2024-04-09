using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Controller
{
    public class DataBase
    {
        private ContactsContext _context;
        public DataBase(string DBconnection)
        {
            _context = new ContactsContext() { ConnectionString = DBconnection };
        }

        public DbSet<Contact> Contacts { get => _context.Contacts; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
