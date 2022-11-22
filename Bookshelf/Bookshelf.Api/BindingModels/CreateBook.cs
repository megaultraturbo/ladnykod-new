using System;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Api.BindingModels
{
    public class CreateBook
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
}

