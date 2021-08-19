using AutoMapper;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.GetGenreDetails
{
   

    public class GetGenreDetailQuery
    {

        private readonly BookStoreInMemoryContext _context;

        public int GenreId { get; set; }

        private readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreInMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {

            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);


            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");

            GenreDetailViewModel retıurnObj = _mapper.Map<GenreDetailViewModel>(genre);

            return retıurnObj;

        }


    }


    public class GenreDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }




    }

}
