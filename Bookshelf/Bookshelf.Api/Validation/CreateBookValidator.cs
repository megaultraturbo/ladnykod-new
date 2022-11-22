using FluentValidation;
using Bookshelf.Api.BindingModels;

namespace Bookshelf.Api.Validation
{
    public class CreateBookValidator: AbstractValidator<CreateBook>
    {
        public CreateBookValidator() {
            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.PagesNumber).NotNull();
        }
    }

}