using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Interface
{
  public  interface IAccount
    {
        Task<string> Register(UserModel userModel);
        Task<string> Login(LoginModel login);
        //Task<UserModel> FindByEmail(string email);

    }
}
