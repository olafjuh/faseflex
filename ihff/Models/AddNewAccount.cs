using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class AddNewAccount
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fist name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "acces too")]
        public string AccesTo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
