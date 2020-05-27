using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookstoreModel.Model;

namespace BookstoreRepository.Interface
{
  public interface IBookRepository
    {
      Task AddBook(BookModel bookmodel);

    }
}
