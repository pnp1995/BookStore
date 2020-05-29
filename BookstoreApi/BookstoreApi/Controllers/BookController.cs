using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookstoreManager.Interface;
using BookstoreModel.Model;


namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook book;
        public readonly object Assert;

        public BookController(IBook book)
        {
            this.book = book;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> BookAdd(BookModel bookModel)
        {

            var result = await book.AddBook(bookModel);

            if (!result.Equals(null))
            {

                // var token = this.GenerateToken();
                return this.Ok(new { success = true, data = result, message = "Book Added" });
            }
            else
            {
                return this.BadRequest(new { success = false, result, message = "Book could not be added" });
            }
          
        }

        [HttpPost]
        [Route("image")]
        public IActionResult ImageUpload(int Bookid, IFormFile formFile)
        {
            var result = book.ImageUpload(Bookid, formFile);
            if(!result.Equals(null))
            {
               
                return Ok(new { success = true, data = result, message = "Image Added" });
            }
            else
            {
                return this.BadRequest(new { success = false, result, message = "Image could not be added" });
            }
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetProducts()
        {
            var result = this.book.GetAllBook();

            if (result.Equals(null))
            {
                return this.NotFound("no products found");
            }

            return this.Ok(new { result });

        }



    }
}








