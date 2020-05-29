using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewsAPI.Models
{
    public class BookDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Img { get; set; }

        public BookDTO(Book book)
        {
            ID = book.ID;
            Name = book.Name;
            AuthorName = book.Author?.AuthorName;
            Img = book.Img;
        }
    }
}
