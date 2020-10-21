using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using Server.Singletones;
using Models;
using Server.DataBase;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp([FromBody]Account account) //Метод регистрации
        {
            SQLiteAccountRepository repository = new SQLiteAccountRepository();

            bool registred = repository.Create(account);
            if (registred)
            {
                repository.Save();
                return Ok();
            }
            return Conflict();
            
        }
        
        /// <summary>
        /// Это метод входа в аккаунт
        /// ВНИМАНИЕ! Его стабильная работа не гарантирована, потому, как у автора не было идей, как это проверить сейчас
        /// Ну, по-идее должно работать
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("SignIn")]
        [HttpPost]
        public /*HttpResponseMessage*/ IActionResult SignIn([FromBody]Account account)//Метод входа в аккаунт
        {
            if(CheckAccountData(account.Name, account.Password))
                {
                    string token = TokenManager.GenerateToken(account);
                    
                    HttpResponseMessage message = new HttpResponseMessage();
                    message.Content = new StringContent(token);
                    message.StatusCode = HttpStatusCode.OK;
                    return Ok(token);
                }
            
            //return new HttpResponseMessage(HttpStatusCode.Conflict);
            return Conflict();
        }

        private bool CheckAccountData(string name, string password)
        {
            using (AccountContext context = new AccountContext())
            {
                Account ac = context.Accounts.FirstOrDefault(t => t.Name == name);

                if (ac != null && password == ac.Password)
                {
                    return true;
                }

                return false;
            }
        }
    }
}