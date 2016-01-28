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
        // maccount
        public Account GetAccount(string emailAddress, string password)
        {
            foreach (Account x in ctx.Accounts)
            {
                if (HashPassword.VerifyHashedPassword(x.Password, password))
                {
                    if (x.EmailAddress == emailAddress)
                    {
                        return x;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return null;
            /*Account c = ctx.Accounts.SingleOrDefault(d => d.EmailAddress == emailAddress && d.Password == password);
            return c;*/
        }
        public void AddAccount(Account account)
        {
            ctx.Accounts.Add(account);
            ctx.SaveChanges();
        }
        //mblokken schema
        public IEnumerable<Activity> GetActivities()
        {
            return ctx.Activities;
        }
        public IEnumerable<string> GetLocations()
        {
            List<string> allLocations = new List<string>();
            IEnumerable<Activity> activities = GetActivities();
            foreach (Activity acti in activities)
            {
                if (!allLocations.Contains(acti.location))
                {
                    allLocations.Add(acti.location);
                }
                
            }
            return allLocations;
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
            if (!((ctx.Wishlists.Where(c => c.email == wishlist.email) == null)))
            {
                IEnumerable<Wishlist> oldWishlists = ctx.Wishlists.Where(c => c.email == wishlist.email).ToList();
                foreach (var i in oldWishlists)
                    ctx.Wishlists.Remove(i);

                ctx.Wishlists.Add(wishlist);
                ctx.SaveChanges();
            }
            else
            {
                ctx.Wishlists.Add(wishlist);
                ctx.SaveChanges();
            }
            
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

        public WishlistItem GetWishlistItem(int id)
        {
            WishlistItem wishlistItem = ctx.WishlistItems.SingleOrDefault(c => c.Id == id);
            return wishlistItem;
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