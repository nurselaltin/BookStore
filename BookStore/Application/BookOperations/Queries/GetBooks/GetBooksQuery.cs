using BookStore.Common;
using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreInMemoryContext _context;

        public GetBooksQuery(BookStoreInMemoryContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            var books = _context.Books.OrderBy(x => x.ID).ToList<Book>();

            List<BooksViewModel> bookViewModel = new List<BooksViewModel>();

            foreach (var book in books)
            {

                bookViewModel.Add(new BooksViewModel() 
                {
                
                 Title = book.Title,
                 Author = book.Author,
                 Genre = ((GenreEnum)book.GenreId).ToString(),
                 PageCount = book.PageCount

                
                });
            }


            return bookViewModel;
        }

      


    }


    public  class BooksViewModel
    {

        public string Title { get; set; }

        public string Genre { get; set; } 

        public Author Author { get; set; }

        public int PageCount { get; set; }


    }
}
