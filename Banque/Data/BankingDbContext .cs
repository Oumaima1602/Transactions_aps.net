using Banque.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Banque.Data
{
    public class BankingDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\okhat\\Documents\\Banque.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

    }
}
