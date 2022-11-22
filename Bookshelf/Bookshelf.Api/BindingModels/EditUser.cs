using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Org.BouncyCastle.Ocsp;

namespace Bookshelf.Api.BindingModels
{
    public class EditUser
    {
        [Required]
        [Display(Name = "username")]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
    
    public class EditUserValidator : AbstractValidator<EditUser> {
        public EditUserValidator() {
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}