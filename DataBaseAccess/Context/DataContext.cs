using DataBaseAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Transaction;Trusted_Connection=True;");
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
