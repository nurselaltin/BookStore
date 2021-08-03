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










    }
}
