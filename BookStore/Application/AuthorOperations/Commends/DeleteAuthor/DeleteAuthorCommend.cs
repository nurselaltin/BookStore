using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommend
    {


        private readonly BookStoreInMemoryContext _context;

        private readonly DeleteBookCommend _deleteBookCommend;

        public int AuthorId { get; set; }

        public DeleteAuthorCommend(BookStoreInMemoryContext context, DeleteBookCommend deleteBookCommend)
        {
            _context = context;
            _deleteBookCommend = deleteBookCommend;
        }


        public void Handle()
        {

            var author = _context.Authors.Find(AuthorId);

            if (author is null)
                throw new InvalidOperationException("Böyle bir yazar mevcut değil. ");
            _context.Remove(author);
            _context.SaveChanges();

            //Delete Book 

            var books = _context.Books.Where(x => x.Author.FirstName == author.FirstName).ToList();

            if (books != null)
                foreach (var item in books)
                {
                    _deleteBookCommend.BookId = item.ID;
                    _deleteBookCommend.Handle();
                }
                



        }


    }
}
