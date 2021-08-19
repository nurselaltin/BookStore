using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commends.CreateAuthor
{
    public class CreateAuthorCommendValidator :AbstractValidator<CreateAuthorCommend>
    {


        public CreateAuthorCommendValidator()
        {
            RuleFor(commend => commend.Model.FirstName).MinimumLength(4);
            RuleFor(commend => commend.Model.LastName).NotNull();
        }
    }
}
