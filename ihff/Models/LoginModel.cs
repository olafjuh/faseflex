using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class LoginModel
    {
        // GET: LoginModel
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}