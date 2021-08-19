using AutoMapper;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.GetGenres
{
    public class GetGenresQuery
    {

        private readonly BookStoreInMemoryContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreInMemoryContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {

            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);

            List<GenresViewModel> retıurnObj = _mapper.Map<List<GenresViewModel>>(genres);

            return retıurnObj;
        
        }










    }


    public class GenresViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }




    }


}
