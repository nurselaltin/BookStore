using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.DeleteGenre
{
    public class DeleteGenreCommendValidator:AbstractValidator<DeleteGenreCommend>
    {

        public DeleteGenreCommendValidator()
        {
            RuleFor(commend => commend.GenreId).GreaterThan(0);
        }
    }
}
