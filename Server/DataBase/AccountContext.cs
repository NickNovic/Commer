using System.Linq;
using Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Server.DataBase
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite("Data Source=Accounts.db");
    }
}