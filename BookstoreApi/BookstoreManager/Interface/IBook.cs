using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookstoreModel.Model;
namespace BookstoreManager.Interface
{
   public interface IBook
    {
       Task<string> AddBook(BookModel bookModel);

    }
}
