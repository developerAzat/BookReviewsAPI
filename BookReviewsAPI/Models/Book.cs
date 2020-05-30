using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewsAPI.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }

        public string Img { get; set; }

        public Category Category { get; set; }

        public string Review { get; set; }

        public string Button { get; set; }

        public BookDTO ReturnBookDTO()
        {
            return new BookDTO(this);
        }

        public ReviewDTO ReturnReviewDTO()
        {
            return new ReviewDTO(this);
        }
    }
}
