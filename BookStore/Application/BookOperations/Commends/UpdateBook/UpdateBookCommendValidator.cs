
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommendValidator : AbstractValidator<UpdateBookCommend>
    {


        public UpdateBookCommendValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);

            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
