using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorQuery
    {



        private readonly BookStoreInMemoryContext _context;

        public GetAuthorQuery(BookStoreInMemoryContext context)
        {
            _context = context;
        }


        public List<GetAuthorViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList<Author>();

            List<GetAuthorViewModel> authorsViewModel = new List<GetAuthorViewModel>();

            foreach (var item in authors)
            {
                authorsViewModel.Add(
                    new GetAuthorViewModel()
                    {
                         Id = item.Id,
                         FirstName = item.FirstName,
                         LastName = item.LastName,
                         Birthdate = item.Birthdate
                    }
                    );

            }


            return authorsViewModel;


        }


    }




    public class GetAuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }



        public DateTime Birthdate { get; set; }

       
    }
}
