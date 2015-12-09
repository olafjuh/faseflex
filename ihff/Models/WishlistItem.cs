using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int wishID { get; set; }
        public int actID { get; set; }

        public WishlistItem(int Id, int wishID, int actID)
        {
            this.Id = Id;
            this.wishID = wishID;
            this.actID = actID;
        }

        public WishlistItem()
        {

        }
    }
}