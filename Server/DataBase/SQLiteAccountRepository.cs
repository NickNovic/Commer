using System.Collections.Generic;
using System.Linq;
using Models;

namespace Server.DataBase
{
    public class SQLiteAccountRepository : IRepository<Account>
    {
        private AccountContext db;
        
        public void Dispose()//Я не знаю что это, если ты знаешь, то  скажите пожалуйста :D
        {
            db.Dispose();
        }

        public IEnumerable<Account> GetList()
        {
            return db.Accounts;
        }

        public Account GetItem(int id)
        {
            Account account = db.Accounts.FirstOrDefault(t => t.Id == id);
            return account;
        }

        public bool Create(Account item)
        {
            var ac = db.Accounts.FirstOrDefault(t => t.Email == item.Email || t.Name == item.Name);
            
            if (ac != null)
            {
                db.Accounts.Add(item);
                return true;
            }
            
            return false;
            
        }

        public bool Update(Account item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            Account ac = db.Accounts.FirstOrDefault(t => t.Id == id);
            if (ac != null)
            {
                db.Accounts.Remove(ac);
                return true;
            }
            
            return false;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}