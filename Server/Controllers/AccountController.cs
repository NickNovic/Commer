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
            using(AccountContext context = new AccountContext())
            {
                if(account != null)
                {
                    var ac = context.Accounts.Where(t => (t.Name == account.Name || t.Email == account.Email)).FirstOrDefault();
                    
                    
                    if(ac == null)
                    {
                        context.Accounts.Add
                        (
                            new Account()
                            {
                                Name = account.Name,
                                Password = account.Password,
                                Email = account.Email
                            }
                        );
                        
                        context.SaveChanges();
                        return Ok();
                    }
                }
            }

            return Conflict();
        }
        
        [Route("SignIn")]
        [HttpPost]
        public HttpResponseMessage SignIn([FromBody]Account account)//Метод входа в аккаунт
        {
            using(AccountContext context = new AccountContext())
            {
                var ac = (Account)context.Accounts.Where(t => t.Name == account.Name && t.Password == account.Password).FirstOrDefault();

                if(ac != null)
                {
                    string token = TokenManager.GenerateToken(account);
                    
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(token)
                    };
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }
    }
}