using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using Server.Singletones;
using Models.Account;
using Server.DataBase;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static SQLiteAccountRepository Repository = new SQLiteAccountRepository();
        
        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp([FromBody]RegistrationModel account) //Метод регистрации
        {
            if (Repository.Register(account))
            {
                Account acc = (Account)account;
                Repository.Create(acc);
                Repository.Save();
                
                return Ok();
            }
            return Conflict();
        }
        
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("SignIn")]
        [HttpPost]
        public IActionResult SignIn([FromBody]AuthorizationModel account)//Метод входа в аккаунт
        {
            if(Repository.Authorize(account))
            { 
                string token = TokenManager.GenerateToken(account);
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}