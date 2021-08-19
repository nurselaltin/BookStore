using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.CreateGenre
{
    public class CreateGenreCommendValidator : AbstractValidator<CreateGenreCommend>
    {
        public CreateGenreCommendValidator()
        {
            RuleFor(commend => commend.Model.Name).MinimumLength(4);
        }
    }
}
