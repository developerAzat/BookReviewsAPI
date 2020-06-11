using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReviewsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ApiContext db {get;set;}

        public CategoriesController(ApiContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return db.Categories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BookDTO>> Get(int id)
        {
            var books = new List<BookDTO>();

            db.Books.Include(b => b.Author).Include(b => b.Category)
                .Where(b => b.Category.CategoryID == id).ToList().ForEach(b => books.Add(b.ReturnBookDTO()));

            return books;
        }
    }
}
