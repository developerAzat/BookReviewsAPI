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

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            var books = new List<BookDTO>();

            db.Books.Include(b => b.Author).ToList().ForEach(book => 
                                        books.Add(book.ReturnBookDTO()));

            return books;
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            return db.Books.Include(b => b.Author).ToList().FirstOrDefault(b => b.ID == id)?.ReturnBookDTO();
        }

        [Route("notused")]
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetNotUsed()
        {
            var notUsedBooks = db.Books.Where(b => !b.Used).ToList();
            var returnBooks = new List<BookDTO>();

            foreach(var book in notUsedBooks)
            {
                returnBooks.Add(book.ReturnBookDTO());

                book.Used = true;
                db.Books.Update(book);
            }

            db.SaveChanges();

            return returnBooks.ToList();
        }

        
    }
}
