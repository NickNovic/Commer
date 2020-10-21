using System;
using Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace ClientMethods
{
    public class AccountMethods
    {
        public static async Task SignUp(Account account)
        {
            //"http://localhost:5000/account/SignUp/"
            await Server.PostAsync(account, "http://localhost:5000/account/SignUp/");
        }

        public static async Task SignIn(Account account)
        {
            await Server.PostAsync(account, "http://localhost:5000/account/SignIn/");
        }
        static bool CheckPassword(string password)
        {
            //Проверки пароля на то, можно ли такой использовать
            return false;
        }

        static bool CheckName(string name)
        {
            //Проверка имени на то, возможно ли такое использовать
            return false;
        }
    }
}
