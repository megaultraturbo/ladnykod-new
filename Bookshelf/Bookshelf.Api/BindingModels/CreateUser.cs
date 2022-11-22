using System;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Ocsp;

namespace Bookshelf.Api.BindingModels
{
    public class CreateUser
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
}

