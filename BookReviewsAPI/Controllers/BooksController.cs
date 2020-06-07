using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReviewsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        ApiContext db;

        public BooksController(ApiContext DB)
        {
            db = DB;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            var books = new List<BookDTO>();

            db.Books.Include(b => b.Author).ToList().ForEach(book => 
                                        books.Add(book.ReturnBookDTO()));

            return books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            return db.Books.Include(b => b.Author).ToList().FirstOrDefault(b => b.ID == id)?.ReturnBookDTO();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
