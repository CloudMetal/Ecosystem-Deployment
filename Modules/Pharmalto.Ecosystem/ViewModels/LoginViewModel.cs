using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmalto.Ecosystem.ViewModels
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Email address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [UIHint("Checkbox"), Display(Name = "Keep me logged in")]
        public bool CreatePersistentCookie { get; set; }
    }
}