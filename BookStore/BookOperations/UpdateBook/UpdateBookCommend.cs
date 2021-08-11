using AutoMapper;
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

        public UpdateBookModel Model { get; set; }

        public int BookId { get; set; }

        private readonly BookStoreInMemoryContext _context;

        private readonly IMapper _mapper;
   
        public UpdateBookCommend(BookStoreInMemoryContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public UpdateBookViewModel Handle()
        {

            var book = _context.Books.Find(BookId);

            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil");

          

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            

            _context.Books.Update(book);
            _context.SaveChanges();


         

            var bookViewModel = new UpdateBookViewModel() {

                Title = book.Title,
     
                Genre = ((GenreEnum)book.GenreId).ToString(),
                

            };

            return bookViewModel;



        }

         





    }

    public class UpdateBookModel
    {

   
        public string Title { get; set; }

        public int GenreId { get; set; }

       



    }

    public class UpdateBookViewModel
    {
        public string Title { get; set; }

        public string Genre { get; set; }

     


    }
}
