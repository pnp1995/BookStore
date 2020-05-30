using BookstoreModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManager.Interface
{
   public interface ICart
    {
        Task<int> AddCart(CartModel cartModel);
        IQueryable GetCartDetail();
        Task<int> UpdateCart(CartModel newCartModel);
        Task<CartModel> DeleteCart( long id);
        int AllNumberOfBook();
    }
}
