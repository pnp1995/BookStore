using BookstoreManager.Interface;
using BookstoreModel.Model;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Manager
{
 public class AccountManager:IAccount
    {
        private readonly IAccountRepository accountRepository;
        public AccountManager(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<string> Register(UserModel userModel)
        {

            try
            {
                await this.accountRepository.Register(userModel);
                return "Registration Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            public async Task<string> Login(LoginModel loginModel)
            {
                try
                {
                    var Token = await accountRepository.Login(loginModel);
                    return Token;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

        
 }
}
