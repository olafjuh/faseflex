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

        //mblokken schema
        public IEnumerable<Activities> GetActivities()
        {

            return ctx.Activities;
        }
        

        
        //wishlist
        public IEnumerable<Wishlist> GetAllWishlists()
        {
            return ctx.Wishlists;
            
        }

        public Wishlist GetWishlist(string email)
        {
            return ctx.Wishlists.SingleOrDefault(a => a.email == email);
        }

        public IEnumerable<WishlistItem> GetAllItems(Wishlist wishlist)
        {
            return ctx.WishlistItems.Where(c => c.wishID == wishlist.Id);
        }
        
        public void SaveWishlist(Wishlist wishlist)
        {
            ctx.Wishlists.Add(wishlist);
            ctx.SaveChanges();
        }

        public void SaveWishlistItems(IEnumerable<WishlistItem> wishlistItems)
        {
            foreach (var item in wishlistItems)
            ctx.WishlistItems.Add(item);
            ctx.SaveChanges();
        }

        //save wishlist

        //delete wishlist

        //add activity to wishlist
        
        //remove activity to wishlist

        //edit activity in wishlist
    }
}