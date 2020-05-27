using System;
using System.Collections.Generic;
using System.Text;
using BookstoreModel.Model;
using System.Threading.Tasks;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
namespace BookstoreRepository.Repository
{
   public class BookRepository : IBookRepository
    {
        private readonly UserContext userContext;
        public BookRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }


        public Task AddBook(BookModel bookModel)
        { 

        BookModel bookModel1 = new BookModel()
        {
            Bookid = bookModel.Bookid,
            Bookname = bookModel.Bookname,
            Description = bookModel.Description,
            Author = bookModel.Author,
            Price = bookModel.Price,
            Image = bookModel.Image,
            Review = bookModel.Review,

        };
            userContext.BookTable.Add(bookModel);
            return Task.Run(() => userContext.SaveChanges());
        }
}
}
