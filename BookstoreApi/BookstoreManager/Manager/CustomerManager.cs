using BookstoreManager.Interface;
using BookstoreModel.Model;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Manager
{
   public class CustomerManager : ICustomer
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Task<int> CustomerAddress(CustomerModel customerModel)
        {
            return this.customerRepository.CustomerAddress(customerModel);
        }
        public CustomerModel GetCustomerDetail(string Emailid)
        {
            return this.customerRepository.GetCustomerDetail(Emailid);
        }
    }
}
