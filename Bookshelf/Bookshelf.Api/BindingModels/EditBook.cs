using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Bookshelf.Api.BindingModels
{
    public class EditBook
    {
        [Required]
        [Display(Name = "AuthorId")]
        public int AuthorId { get; set; }
        
        [Required]
        [Display(Name = "title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "PagesNumber")]
        public int PagesNumber { get; set; }
    }

    public class EditBookValidator : AbstractValidator<EditBook>
    {
        public EditBookValidator()
        {
            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.Title).EmailAddress();
            RuleFor(x => x.PagesNumber).NotNull();
        }
    }
}