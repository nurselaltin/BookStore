using AutoMapper;
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

        private readonly IMapper _mapper;
        public CreateBookCommend(BookStoreInMemoryContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {

            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            /*
             * Mapplemedn önceki eşitleme
            book = new Book();
            book.Title = Model.Title;
            book.Author = Model.Author;
            book.PageCount = Model.PageCount;
            

            */

            book = _mapper.Map<Book>(Model);

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
