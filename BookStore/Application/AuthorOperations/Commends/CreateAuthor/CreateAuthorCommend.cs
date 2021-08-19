using AutoMapper;
using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commends.CreateAuthor
{
    public class CreateAuthorCommend
    {

        private readonly BookStoreInMemoryContext _context;
        public CreateAuthorModel Model { get; set; }

        private readonly IMapper _mapper;

        public CreateAuthorCommend(BookStoreInMemoryContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {

            var author = _context.Authors.SingleOrDefault(x => x.FirstName.ToLower() == Model.FirstName.ToLower());

            if (author != null)
                throw new InvalidOperationException("Bu isimde Yazar mevcut!");

            //Mapper 

            author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);
            _context.SaveChanges();


        }



    }

    public class CreateAuthorModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }



    }
}
