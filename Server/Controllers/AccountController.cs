using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp([FromBody]Account account)
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
        public bool SignIn([FromBody]Account account)
        {
            using(AccountContext context = new AccountContext())
            {
                var ac = (Account)context.Accounts.Where(t => t.Name == account.Name && t.Password == account.Password).FirstOrDefault();

                if(ac != null)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet]
        public string Return()
        {
            return "Works!";
        }
    }
}