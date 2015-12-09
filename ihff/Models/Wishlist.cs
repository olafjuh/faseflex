using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string email { get; set; }
        public bool paid { get; set; }

        public Wishlist()
        {

        }

        public Wishlist(string email, bool paid)
        {
            this.email = email;
            this.paid = paid;
        }
    }
}