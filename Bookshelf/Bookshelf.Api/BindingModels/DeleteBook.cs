using System;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Api.BindingModels
{
    
    public class DeleteBook
    {
        [Required]
        [Display(Name = "title")]
        public int BookId { get; set; }
    }    
}
