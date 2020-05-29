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
                return "Book Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  Task<BookModel> ImageUpload( int Bookid , IFormFile file)
        {
            try
            {
                var result = bookRepository.ImageUpload(Bookid, file);
                return result;
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

        public IList<BookModel> GetAllBook()
        {
            IList<BookModel> list = new List<BookModel>();
            list = bookRepository.GetAllBook();

            if (list != null)
            {
                return list;
            }
            else
            {
                throw new Exception();
            }
        }


    }
}
