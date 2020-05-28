using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookstoreModel.Model;
using Microsoft.AspNetCore.Http;


namespace BookstoreManager.Interface
{
   public interface IBook
    {
       Task<string> AddBook(BookModel bookModel);
        Task<BookModel> ImageUpload( int Bookid, IFormFile formFile);

    }
}
