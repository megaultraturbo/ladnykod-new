using FluentValidation;
using Bookshelf.Api.BindingModels;

namespace Bookshelf.Api.Validation
{
  public class CreateUserValidator : AbstractValidator<CreateUser>
  {
    public CreateUserValidator()
    {
      RuleFor(x => x.Username).NotNull();
      RuleFor(x => x.Email).NotNull().EmailAddress();
      RuleFor(x => x.Password).NotNull();
    }
  }

}

