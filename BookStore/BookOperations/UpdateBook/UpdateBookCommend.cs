using BookStore.Common;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommend
    {

        public UpdateBookInputModel Model { get; set; }

        private readonly BookStoreInMemoryContext _context;
   
        public UpdateBookCommend(BookStoreInMemoryContext context)
        {
            _context = context;
        }


        public UpdateBookOutputModel Handle()
        {

            var book = _context.Books.Find(Model.ID);

            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil");

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Author = Model.Author != default ? Model.Author : book.Author;

            _context.Books.Update(book);
            _context.SaveChanges();


            //return to oupt model

            var bookViewModel = new UpdateBookOutputModel() {

                Title = book.Title,
                Author = book.Author,
                Genre = book.GenreId,
                PageCount = book.PageCount

            };

            return bookViewModel;



        }

         





    }

    public class UpdateBookInputModel
    {

        public int ID { get; set; }
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public string Author { get; set; }


    }

    public class UpdateBookOutputModel
    {
        public string Title { get; set; }

        public int Genre { get; set; }

        public int PageCount { get; set; }

        public string Author { get; set; }


    }
}
