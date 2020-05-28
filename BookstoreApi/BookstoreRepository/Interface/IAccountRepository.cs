using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Interface
{
   public interface IAccountRepository
    {
        Task Register(UserModel userModel);
        Task<string> Login(LoginModel login);


    }
}
