using System;
using System.Collections.Generic;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using BookstoreModel.Model;
using System.Threading.Tasks;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
using System.Linq;
using Microsoft.AspNetCore.Http;

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

        public Task<BookModel> ImageUpload(int Bookid, IFormFile file)
        {
            var path = file.OpenReadStream();
            var fileName = file.FileName;
            CloudinaryDotNet.Account cloudinary = new CloudinaryDotNet.Account("dtddmoers", "745684864855497", "b4WAINSfnC1hJPAyikC525T3HUM");
            CloudinaryDotNet.Cloudinary cloud = new CloudinaryDotNet.Cloudinary(cloudinary);
            var Uploadfile = new ImageUploadParams()
            {
                File = new FileDescription(fileName, path)
            };
            var data = cloud.Upload(Uploadfile);
            var result = userContext.BookTable.Where(i => i.Bookid == Bookid).SingleOrDefault();
            result.Image = data.Uri.ToString();
            userContext.SaveChanges();

            //return result.Image ;
            //var profileUrl = result.ProductImage;
            //return profileUrl;
            return Task.Run(() => result);
        }



    }
}
