
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class BookStoreInMemoryContext : DbContext
    {



        public BookStoreInMemoryContext(DbContextOptions<BookStoreInMemoryContext> options) : base(options)
        {

        }



        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }










    }
}
