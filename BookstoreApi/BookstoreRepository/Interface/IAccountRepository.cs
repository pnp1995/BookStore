using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Interface
{
   public interface IAccountRepository
    {
        Task Adduser(UserModel userModel);
        Task<string> Login(LoginModel login);


    }
}
