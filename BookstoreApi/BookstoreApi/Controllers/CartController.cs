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
    public class CartController : ControllerBase
    {
        private readonly ICart cart;
        public readonly object Assert;

        public CartController(ICart cart)
        {
            this.cart = cart;
        }

        [Route("addcart")]
        [HttpPost]
        public async Task<IActionResult> AddCart(CartModel bookModel)
        {
            var result = await this.cart.AddCart(bookModel);
            return this.Ok(result);
        }

        [Route("getcart")]
        [HttpGet]
        public IQueryable GetCartDetail()
        {
            var cartContext = this.cart.GetCartDetail();
            return cartContext;
        }

        [Route("updatecart")]
        [HttpPut]
        public async Task<IActionResult> UpdateCart(CartModel newcartModel)
        {
            var result = await this.cart.UpdateCart(newcartModel);
            if (result == 0)
                return BadRequest(ModelState);
            else
                return this.Ok(newcartModel);
        }

        [Route("deletecart")]
        [HttpDelete]
        public async Task<CartModel> DeleteCart(long id)
        {
            var result = await this.cart.DeleteCart(id);
            return result;

        }

        [Route("count")]
        [HttpGet]
        public IActionResult AllNumberOfBook()
        {
            var result = this.cart.AllNumberOfBook();

            return this.Ok(result);
        }
    }
}
