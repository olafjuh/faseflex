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
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];

            return View(wishlist.wishlistItems);
        }

        public ActionResult SaveWishlist()
        {
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult SaveWishlist(Wishlist wishlist)
        {
            //todo check to see if wishlist is the session wishlist.

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

        //[HttpPost]
        //public ActionResult NewWishlist()
        //{
        //    Session["active_wishlist"] = new Wishlist();
        //    Session["active_wishlistitems"] = new IEnumerable<WishlistItem>();

        //    return View("Index");
        //}

        public ActionResult GetWishlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWishlist(Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                Wishlist checkedwishlist = repository.GetWishlist(wishlist.email);
                Session["active_wishlist"] = checkedwishlist;
                return RedirectToAction("Index");
            }
            return View(wishlist);
        }
    }
}
