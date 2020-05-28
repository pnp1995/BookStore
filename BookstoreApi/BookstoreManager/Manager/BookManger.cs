using System;
using System.Collections.Generic;
using System.Text;
using BookstoreManager.Interface;
using BookstoreRepository.Interface;
using System.Threading.Tasks;
using BookstoreModel.Model;
using Microsoft.AspNetCore.Http;


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

        public  Task<BookModel> Image( int Bookid , IFormFile file)
        {
            try
            {
                var res = bookRepository.Image(Bookid, file);
                return res;
                //if (file != null && !Bookid.Equals(null))
                //{
                //    var result = await this.bookRepository.BookImageUpload(file, Bookid);

                //    if (result != null)
                //    {
                //        return result;
                //    }
                //    else
                //    {
                //        throw new Exception("no image url returned");
                //    }
                //}           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
