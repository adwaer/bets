﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using Bets.Domain;
using Microsoft.AspNet.Identity.Owin;

namespace Bets.Identity.Controllers
{
    public class SimpleCustomerController : ApiController
    {
        private readonly SignInManager<SimpleCustomerAccount, Guid> _signInManager;

        public SimpleCustomerController(SignInManager<SimpleCustomerAccount, Guid> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IHttpActionResult> Get(string login, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(login, password, true, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(login, true);
                return Ok();
            }
            return BadRequest(result.ToString());
        }
    }
}
