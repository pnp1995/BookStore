using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Interface
{
   public interface ICartRepository
    {
        Task<int> AddCart(CartModel cartModel);
        IQueryable GetCartDetail();
        Task<int> UpdateCart(CartModel OldBookDetails);
        Task<CartModel> DeleteCart(long BookId);

        int AllNumberOfBook();
    }
}
