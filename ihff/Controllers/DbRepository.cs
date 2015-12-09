using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ihff.Models;

namespace ihff.Controllers
{
    public class DbRepository
    {
        private ihffContext ctx = new ihffContext();


        public IEnumerable<Wishlist> GetAllWishlists()
        {
            return ctx.wishlists;
        }

        public IEnumerable<WishlistItem> GetAllItems(Wishlist wishlist)
        {
            return ctx.wishlistItems.Where(c => c.wishID == wishlist.Id);
        }
        

        //save wishlist

        //delete wishlist

        //add activity to wishlist
        
        //remove activity to wishlist

        //edit activity in wishlist
    }
}