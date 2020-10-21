using System.Collections.Generic;
using System.Linq;
using Models;

namespace Server.DataBase
{
    public class SQLiteAccountRepository : Repository<Account>
    {
        private AccountContext db;

        public SQLiteAccountRepository()
        {
            db = new AccountContext();
        }
        
        public override void Dispose()//Я не знаю что это, если ты знаешь, то  скажите пожалуйста :D
        {                    //Кажется знаю и кажется, это нужно просто оставить как есть
            db.Dispose();
        }

        public override IEnumerable<Account> GetList()
        {
            return db.Accounts;
        }

        public override Account GetItem(int id)
        {
            Account account = db.Accounts.FirstOrDefault(t => t.Id == id);
            return account;
        }

        public override bool Create(Account item)
        {
            var ac = db.Accounts.FirstOrDefault(t => t.Email == item.Email || t.Name == item.Name);
            
            if (ac == null)
            {
                db.Accounts.Add(item);
                return true;
            }
            
            return false;
            
        }

        public override bool Update(Account item)
        {
            Account ac = db.Accounts.FirstOrDefault(t => t.Id == item.Id);
            if (ac != null)
            {
                db.Accounts.Update(item);
                return true;
            }

            return false;
        }

        public override bool Delete(int id)
        {
            Account ac = db.Accounts.FirstOrDefault(t => t.Id == id);
            if (ac != null)
            {
                db.Accounts.Remove(ac);
                return true;
            }
            
            return false;
        }

        public override void Save()
        {
            db.SaveChanges();
        }
    }
}