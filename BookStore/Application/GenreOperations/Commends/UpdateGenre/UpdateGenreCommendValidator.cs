using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOprations.Commends.UpdateGenre
{
    public class UpdateGenreCommendValidator : AbstractValidator<UpdateGenreCommend>
    {

        public UpdateGenreCommendValidator()
        {
            RuleFor(commend => commend.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}
