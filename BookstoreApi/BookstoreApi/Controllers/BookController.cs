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
            try
            {
                var result = await book.AddBook(bookModel);
                return this.Ok(new { result });
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("image")]
        public IActionResult ImageUpload(int Bookid, IFormFile formFile)
        {
            try
            {
                var result = book.ImageUpload( Bookid, formFile);
                return Ok(new { result });
            }
            catch (Exception ex)
            {


                return BadRequest(ex.Message);
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








