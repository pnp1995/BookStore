using System;
using System.Collections.Generic;
using System.Text;
using BookstoreManager.Interface;
using BookstoreRepository.Interface;
using System.Threading.Tasks;
using BookstoreModel.Model;


namespace BookstoreManager.Manager
{
    public class BookManger : IBook
    {
        private readonly IBookRepository bookRepository;

        public BookManger(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<string> AddBook(BookModel bookModel)
        {

            try
            {
                await this.bookRepository.AddBook(bookModel);
                return "Add book Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
