using BookstoreManager.Interface;
using BookstoreModel.Model;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Manager
{
   public class CartManager : ICart
    {

        private readonly ICartRepository cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public Task<int> AddCart(CartModel cartModel)
        {
            return this.cartRepository.AddCart(cartModel);
        }

        public IQueryable GetCartDetail()
        {
            return this.cartRepository.GetCartDetail();
        }

        public Task<CartModel> DeleteCart(long BookId)
        {
            var result = this.cartRepository.DeleteCart(BookId);
            return result;
        }
        public async Task<int> UpdateCart(CartModel newCartModel)
        {
            return await this.cartRepository.UpdateCart(newCartModel);
        }


        public int AllNumberOfBook()
        {
            return this.cartRepository.AllNumberOfBook();
        }

    }
}
