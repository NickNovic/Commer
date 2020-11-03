using System.Collections.Generic;
using System.Linq;
using Models.Account;

namespace Server.DataBase
{
    public class SQLiteAccountRepository : IAccountRepository<Account>
    {
        private AccountContext db;

        public SQLiteAccountRepository()
        {
            db = new AccountContext();
        }
        
        public void Dispose()//Я не знаю что это, если ты знаешь, то  скажите пожалуйста :D
        {                    //Кажется знаю и кажется, это нужно просто оставить как есть
            db.Dispose();
        }

        public Account GetItem(int id)
        {
            Account account = db.Accounts.FirstOrDefault(t => t.Id == id);
            return account;
        }

        public bool Create(Account item)
        {
            var ac = db.Accounts.FirstOrDefault(t => t.Email == item.Email || t.Name == item.Name);
            
            if (ac == null)
            {
                db.Accounts.Add(item);
                return true;
            }
            return false;
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

        public Account SearchByEmail(string email)
        {
            var ac = db.Accounts.FirstOrDefault(t => t.Email == email);
            return ac;
        }

        public Account SearchByName(string name)
        {
            var ac = db.Accounts.FirstOrDefault(t => t.Name == name);
            return ac;
        }

        public bool ExistsWithEmail(string email)
        {
            var ac = SearchByEmail(email);
            return AccountState(ac);
        }

        public bool ExistsWithName(string name)
        {
            var ac = SearchByName(name);
            return AccountState(ac);
        }

        public bool AccountState(Account ac)
        {
            if (ac != null)
            {
                return true;
            }
            return false;
        }

        public bool Authorize(AuthorizationModel authorizationModel)//Найти нормальные имена
        {
            var acc = SearchByEmail(authorizationModel.Email);
            if (acc != null)
            {
                return authorizationModel.Password == acc.Password;    
            }
            return false;
        }

        public bool Register(RegistrationModel registrationModel)//Найти нормальные имена
        {
            if (!ExistsWithEmail(registrationModel.Email) && !ExistsWithName(registrationModel.Name))
            {
                Account registerAccount = (Account) registrationModel;
                return true;
            }

            return false;
        }
    }
}