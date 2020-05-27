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
    public class BookController1 : ControllerBase
    {
        private readonly IBook book;
        public readonly object Assert;

        public BookController1(IBook book)
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
    }
}
