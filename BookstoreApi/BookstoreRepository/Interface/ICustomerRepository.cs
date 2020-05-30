using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Interface
{
   public  interface ICustomerRepository
    {
        Task<int>CustomerAddress(CustomerModel address);
        CustomerModel GetCustomerDetail(string Emailid);
    }
}
