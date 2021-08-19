using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.UpdateGenre
{
    public class UpdateGenreCommend
    {

        public UpdateGenreModel Model { get; set; }

        private readonly BookStoreInMemoryContext _context;


        public int GenreId { get; set; }

        public UpdateGenreCommend(BookStoreInMemoryContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü mevcut değil");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Bu isimde kitap türü bulunmaktadır.");



            genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.Update(genre);
            _context.SaveChanges();

        }

    }

    public class UpdateGenreModel
    {

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
