using BookStore.Application.AuthorOperations.DeleteAuthor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteAuthorCommendValidator : AbstractValidator<DeleteAuthorCommend>
    {


        public DeleteAuthorCommendValidator()
        {
            RuleFor(commend => commend.AuthorId).GreaterThan(0);
        }
    }
}
