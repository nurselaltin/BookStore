using AutoMapper;
using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {

        private readonly BookStoreInMemoryContext _context;
        private readonly IMapper _mapper;

        public int AuthorId { get; set; }

        public GetAuthorDetailQuery(BookStoreInMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public GetAuthorDetailViewModel Handle()
        {

            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author != null)
                throw new InvalidOperationException("Böyle bir kitap mevcut değil!");


            var authorViewModel = _mapper.Map<GetAuthorDetailViewModel>(author);

            return authorViewModel;


        }



    }


    public class GetAuthorDetailViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Book> Book { get; set; }
    }
}
