using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.CreateGenre
{
    public class CreateGenreCommend
    {

        private readonly BookStoreInMemoryContext _context;

        public CreateGenreModel Model { get; set; }

        //private readonly IMapper _mapper;

        public CreateGenreCommend(BookStoreInMemoryContext context)
        {
            _context = context;
           // _mapper = mapper;
        }



        public void Handle()
        {

            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre != null)
                throw new InvalidOperationException("Böyle bir genre mevcut değil.");
           
            genre = new Genre
            {
                Name = Model.Name
                
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }


    public class CreateGenreModel
    {
        public string Name { get; set; }
    }

}
