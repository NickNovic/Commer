using System;
using Models.Account;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace ClientMethods
{
    public class AccountMethods
    {
        public static async Task<HttpResponseMessage> SignUp(RegistrationModel account)
        {
            //"http://localhost:5000/account/SignUp/"
            HttpResponseMessage message = await Server.PostAsync(account, "http://localhost:5000/account/SignUp/");
            return message;
        }

        public static async Task<HttpResponseMessage> SignIn(AuthorizationModel account)
        {
            HttpResponseMessage message = await Server.PostAsync(account, "http://localhost:5000/account/SignIn/");
            return message;
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
