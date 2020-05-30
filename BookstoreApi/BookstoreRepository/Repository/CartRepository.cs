using BookstoreModel.Model;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreRepository.Repository
{
  public class CartRepository: ICartRepository
    {
        private readonly UserContext userContext;
        public CartRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public Task<int> AddCart(CartModel cartModel)
        {
            this.userContext.CartTable.Add(cartModel);

            var result = this.userContext.SaveChangesAsync();
            return result;
        }

        public IQueryable GetCartDetail()
        {
            var result = this.userContext.CartTable.Join(this.userContext.BookTable,

                Cart => Cart.Cartid,
                Book => Book.Bookid,
                (Cart, Book) =>
                new
                {
                    bookId = Book.Bookid,
                    authorName = Book.Bookname,
                    author = Book.Author,
                    bookImage = Book.Image,
                    bookPrice = Book.Price,
                    cartId = Cart.Cartid,
                    count = Cart.Count
                });
            return result;

        }

        public async Task<int> UpdateCart(CartModel cartModel)
        {
            try
            {
                var oldCartModel = await userContext.CartTable.FindAsync(cartModel.Cartid);
                oldCartModel.Count = cartModel.Count;
                if (oldCartModel.Count <= 0)
                    await DeleteCart(oldCartModel.Bookid);
                return await this.userContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<CartModel> DeleteCart(long cartid)
        {
            CartModel cartModel = this.userContext.CartTable.Find(cartid);
            if (cartModel != null)
            {
                this.userContext.CartTable.Remove(cartModel);
                await this.userContext.SaveChangesAsync();
            }
            return cartModel;

        }

        public int AllNumberOfBook()
        {
            var result = this.userContext.CartTable.Count<CartModel>();
            return result;
        }
    }
}
