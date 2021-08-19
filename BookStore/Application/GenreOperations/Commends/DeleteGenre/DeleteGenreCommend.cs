using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.DeleteGenre
{
    public class DeleteGenreCommend
    {

        private readonly BookStoreInMemoryContext _context;

        public int GenreId { get; set; }

        public DeleteGenreCommend(BookStoreInMemoryContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }



    }
}
