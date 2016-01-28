using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string AccesTo { get; set; }
        public Account()
        {
        }
        public Account(int Id, string FirstName, string LastName, string EmailAddress, 
            string Password, string AccesTo)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmailAddress = EmailAddress;
            this.Password = Password;
            this.AccesTo = AccesTo;

        }
    }
}