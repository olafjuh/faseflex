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
        public IEnumerable<WishlistItem> films;

        //mblokken schema
        public IEnumerable<Activity> GetActivities()
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
            Wishlist wishlist = ctx.Wishlists.Where(m => m.email == email).First();
            wishlist.wishlistItems = ctx.WishlistItems.Where(i => i.wishID == wishlist.Id).ToList();
            
            return wishlist;
        }

        public IEnumerable<WishlistItem> GetAllItems(Wishlist wishlist)
        {
            return ctx.WishlistItems.Where(c => c.wishID == wishlist.Id);
        }
        
        public void SaveWishlist(Wishlist wishlist)
        {
            ctx.Wishlists.Add(wishlist);
            ctx.SaveChanges();
            foreach(var item in wishlist.wishlistItems)
            {
                item.wishID = wishlist.Id;
                ctx.WishlistItems.Add(item);
            }
            ctx.SaveChanges();
        }

        public int GetNewId()
        {
            Wishlist lastwishlist = ctx.Wishlists.OrderByDescending(u => u.Id).FirstOrDefault();
            int b = lastwishlist.Id;
            b = b + 1;
            return b;
        }

        //save wishlist

        //delete wishlist

        //add activity to wishlist
        
        //remove activity to wishlist

        //edit activity in wishlist


        //----------------FILMS

        public List<Activity> GetAllFilms()
        {
            List<Activity> films = new List<Activity>();
            foreach(var i in ctx.Activities)
            {
                films.Add(i);
            }
            return films;
        }

        public Activity GetFilm(int id)
        {
            return ctx.Activities.SingleOrDefault(c => c.Id == id);
        }
    }
}