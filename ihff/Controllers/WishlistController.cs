using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ihff.Models;

namespace ihff.Controllers
{
    public class WishlistController : Controller
    {
        private DbRepository repository = new DbRepository();

        public ActionResult Index()
        {
            //session placeholder
            Wishlist wishlist = repository.GetAllWishlists().First();
            Session["active_wishlist"] = wishlist;

            //should be filled on final version by films / restaurants.
            Session["active_wishlistitems"] = repository.GetAllItems(wishlist);

            //should load session active_wishlistitems later on.
            return View((IEnumerable<WishlistItem>)Session["active_wishlistitems"]);
        }

        public ActionResult SaveWishlist()
        {
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult SaveWishlist(Wishlist wishlist)
        {
            //add check to see if wishlist is the session wishlist.

            if (ModelState.IsValid)
            {
                repository.SaveWishlist(wishlist);

                IEnumerable<WishlistItem> wishlistItems = (IEnumerable<WishlistItem>)Session["active_wishlistitems"];
                foreach (var item in wishlistItems)
                    item.wishID = wishlist.Id;
                repository.SaveWishlistItems(wishlistItems);

                return RedirectToAction("Index");
            }
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult NewWishlist()
        {
            Session["active_wishlistitems"] = new Wishlist();

            return View("Index");
        }

    }
}
