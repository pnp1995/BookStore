using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookstoreModel.Model;
using Microsoft.AspNetCore.Http;


namespace BookstoreRepository.Interface
{
  public interface IBookRepository
    {
      Task AddBook(BookModel bookmodel);
      Task<BookModel> ImageUpload(int Bookid, IFormFile file);

    }
}
