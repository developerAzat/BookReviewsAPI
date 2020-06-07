using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewsAPI.Models
{
    public class ReviewDTO
    {
        public ReviewDTO(Book book)
        {
            BookName = book.Name;
            AuthorName = book.Author?.AuthorName;
            Img = book.Img;
            CategoryName = book.Category?.Name;
            Review = book.Review;
            Button = book.Button;
        }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string Img { get; set; }

        public string CategoryName { get; set; }

        public string Review { get; set; }

        public string Button { get; set; }
    }
}
