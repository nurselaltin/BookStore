using AutoMapper;
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

        private readonly IMapper _mapper;



        public BookDetailQuery(BookStoreInMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }



        public BookDetailViewModel Handle()
        {

            var book = _context.Books.SingleOrDefault(z => z.ID == BookID);

            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil!");

            //Mapplemeden önceki eşleme
            //var bookViewModel = new BookDetailViewModel()
            //{
            //     Author = book.Author,
            //     Genre = ((GenreEnum)book.GenreId).ToString(),
            //     PageCount = book.PageCount,
            //     Title = book.Title

            //};

            var bookViewModel = _mapper.Map<BookDetailViewModel>(book); 

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
