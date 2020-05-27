using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreManager.Interface;
using BookstoreModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount account;
        public readonly object Assert;

        public AccountController(IAccount account)
        {
            this.account = account;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Registration(UserModel userModel)
        {
            try
            {
                var result = await account.Adduser(userModel);
                return this.Ok(new { result });
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                
                var result = await account.Login(loginModel);
                return this.Ok(new { result });
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        //[HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
        //[Route("jwt")]
        //public async Task<object> Find()
        //{

        //    string Email = User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Email).Value;
        //    var result = await account.FindByEmail(Email);
        //    return new
        //    {
        //        result.Emailid,
        //        result.FirstName,
        //        result.LastName,
        //        result.Password
        //    };
        //}


    }
}
