using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetBookDetail
{
    public class BookDetailQueryValidator : AbstractValidator<BookDetailQuery>
    {


        public BookDetailQueryValidator()
        {
            RuleFor(command => command.BookID).GreaterThan(0);
        }

    }
}
