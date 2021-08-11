using BookStore.Common;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetBookDetail
{
    public class BookDetailQuery
    {



        private readonly BookStoreInMemoryContext _context;

        public int BookID { get; set; }



        public BookDetailQuery(BookStoreInMemoryContext context)
        {
            _context = context;

        }



        public BookDetailViewModel Handle()
        {

            var book = _context.Books.SingleOrDefault(z => z.ID == BookID);

            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil!");

            var bookViewModel = new BookDetailViewModel()
            {
                 Author = book.Author,
                 Genre = ((GenreEnum)book.GenreId).ToString(),
                 PageCount = book.PageCount,
                 Title = book.Title
                 
            };

            return bookViewModel;



        }

    }



    public class BookDetailViewModel
    {

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }



    }
        

}
