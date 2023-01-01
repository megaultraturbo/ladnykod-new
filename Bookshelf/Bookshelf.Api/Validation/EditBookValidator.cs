using FluentValidation;
using Bookshelf.Api.BindingModels;

namespace Bookshelf.Api.Validation
{
  public class EditBookValidator : AbstractValidator<EditBook>
  {
    public EditBookValidator()
    {
      RuleFor(x => x.AuthorId).NotNull();
      RuleFor(x => x.Title).NotNull().EmailAddress();
      RuleFor(x => x.PagesNumber).NotNull();
    }
  }

}
