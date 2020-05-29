using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewsAPI.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Book> Books {get;set;}

        public DbSet<Author> Authors {get;set;}

        public DbSet<Category> Categories {get;set;}

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
