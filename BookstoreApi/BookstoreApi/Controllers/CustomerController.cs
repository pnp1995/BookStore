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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customer;
        public readonly object Assert;

        public CustomerController(ICustomer customer) 
        {
            this.customer = customer;
        }
        [Route("addcustomer")]
        [HttpPost]
        public async Task<IActionResult> CustomerAddress(CustomerModel customerModel )
        {
            var result = await this.customer.CustomerAddress(customerModel);
            return this.Ok(result);
        }
        [Route("getalladdress")]
        [HttpGet]
        public IActionResult GetCustomerDetail(string Emailid)
        {
            var result = this.customer.GetCustomerDetail(Emailid);
            if (result != null)
            {
                return this.Ok(result);
            }
            return BadRequest();
        }

    }
}
