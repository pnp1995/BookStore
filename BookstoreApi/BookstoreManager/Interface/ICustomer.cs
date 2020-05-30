using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Interface
{
   public interface ICustomer
    {
        Task<int> CustomerAddress(CustomerModel customerModel);
        CustomerModel GetCustomerDetail(string Emailid);
    }
}
