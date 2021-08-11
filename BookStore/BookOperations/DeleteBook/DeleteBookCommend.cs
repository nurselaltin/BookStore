using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommend
    {


        private readonly BookStoreInMemoryContext _context;

        public int BookId { get; set; }

        public DeleteBookCommend(BookStoreInMemoryContext context)
        {
            _context = context;
        }


        public void Handle()
        {

            var book = _context.Books.Find(BookId);

            if (book is null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil. ");
            _context.Remove(book);
            _context.SaveChanges();


        }


    }
}
