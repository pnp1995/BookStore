using BookstoreModel.Model;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Repository
{
   public class CustomerRepository : ICustomerRepository
    {
        private readonly UserContext userContext;
        public CustomerRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public Task<int> CustomerAddress(CustomerModel address)
        {
            userContext.CustomerTable.Add(address);
            var result = userContext.SaveChangesAsync();
            return result;
        }

        public CustomerModel GetCustomerDetail(string Emailid)
        {
            return this.userContext.CustomerTable.Find(Emailid);
        }

    }
}
