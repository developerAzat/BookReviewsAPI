using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReviewsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public ApiContext db{get;set;}

        public ReviewsController(ApiContext db)
        {
            this.db = db;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public ActionResult<ReviewDTO> Get(int id)
        {
            return db.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefault(b => b.ID == id)?.ReturnReviewDTO();
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
