using System;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Ocsp;

namespace Bookshelf.Api.BindingModels
{
    public class DeleteUser
    {
        [Required]
        [Display(Name = "username")]
        public int UserId { get; set; }
    }
}