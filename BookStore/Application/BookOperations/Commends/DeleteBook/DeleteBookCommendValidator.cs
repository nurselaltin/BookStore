using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommendValidator : AbstractValidator<DeleteBookCommend>
    {


        public DeleteBookCommendValidator()
        {
            RuleFor(commend => commend.BookId).GreaterThan(0);
        }
    }
}
