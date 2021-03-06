﻿using BookstoreModel.Model;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
using Microsoft.IdentityModel.Tokens;
using NuGet.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Linq;

namespace BookstoreRepository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserContext userContext;
        private readonly ApplicationSettings settings;

        public AccountRepository(UserContext userContext, IOptions<ApplicationSettings> _setting)
        {
            this.userContext = userContext;
            settings = _setting.Value;
        }

        public Task Register(UserModel userModel)
        {
            UserModel userModel1 = new UserModel()
            {
                Userid = userModel.Userid,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Emailid = userModel.Emailid,
                Password = userModel.Password,
            };
            userContext.UserTable.Add(userModel1);
            return Task.Run(() => userContext.SaveChanges());
        }

        public async Task<string> Login(LoginModel login)
        {
            var result = userContext.UserTable.Where(i => i.Emailid == login.Emailid && i.Password == login.Password).SingleOrDefault();
            if (result != null)
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       //new Claim(ClaimTypes.Email,login.Emailid)
                    }),
                    Expires = DateTime.UtcNow.AddDays(20),
                    SigningCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var securitytoken = tokenhandler.CreateToken(tokenDescriptor);
                var Token = tokenhandler.WriteToken(securitytoken);
                return await Task.Run(() => Token);
            }
            else
            {
                return null;
            }
        }

    }
}
