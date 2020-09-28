using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Server
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public static bool Add(Account account)
        {
            using(AccountContext context = new AccountContext())
            {
                Account acc = context.Accounts.Where(a => a.Name == account.Name || a.Email == account.Email).FirstOrDefault();
                
                bool IsNullOrEmpty = string.IsNullOrWhiteSpace(account.Name) |
                                    string.IsNullOrEmpty(account.Password) | 
                                    string.IsNullOrWhiteSpace(account.Email);

                if(acc != null & !IsNullOrEmpty)
                {
                    context.Accounts.Add(account);
                    return true;
                }
                return false;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite("Data Source=Accounts.db");
    }
}