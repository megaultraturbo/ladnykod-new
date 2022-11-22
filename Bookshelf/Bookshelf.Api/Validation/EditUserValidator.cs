using FluentValidation;
using Bookshelf.Api.BindingModels;

namespace Bookshelf.Api.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser> {
        public EditUserValidator() {
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}