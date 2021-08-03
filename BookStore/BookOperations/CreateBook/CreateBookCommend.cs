using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommend
    {


        private readonly BookStoreInMemoryContext _context;
        public CreateBookModel Model { get; set; }
        public CreateBookCommend(BookStoreInMemoryContext context)
        {
            _context = context;
        }


        public void Handle()
        {

            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            book = new Book();
            book.Title = Model.Title;
            book.Author = Model.Author;
            book.PageCount = Model.PageCount;
            _context.Books.Add(book);
            _context.SaveChanges();


        }


    }



    public class CreateBookModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public string Author { get; set; }


    }
}
