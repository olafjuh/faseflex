using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ihff.Models;
using System.Web.Routing;

namespace ihff.Controllers
{
    public class WishlistController : Controller
    {
        private DbRepository repository = new DbRepository();

        public ActionResult Index()
        {
            if (Session["active_wishlist"] == null)
            {
                Wishlist nwWishlist = new Wishlist();
                Session["active_wishlist"] = nwWishlist;
                return View(nwWishlist);

            }
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];
            return View(wishlist);
            
            
        }

        public ActionResult SaveWishlist()
        {
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];
            wishlist.Id = repository.GetNewId();
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult SaveWishlist(Wishlist wishlist)
        {
            Wishlist sessionWishlist = (Wishlist)Session["active_wishlist"];
            wishlist.wishlistItems = sessionWishlist.wishlistItems;
            foreach (var i in wishlist.wishlistItems)
            {
                i.wishID = wishlist.Id;
            }

            if (ModelState.IsValid)
            {
                repository.SaveWishlist(wishlist);
                return RedirectToAction("Index", "Wishlist");
            }
            return View(wishlist);
        }

        public ActionResult GetWishlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWishlist(Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                //if (repository.CheckEmail(wishlist.email))
                //{
                    Wishlist checkedwishlist = repository.GetWishlist(wishlist.email);
                    Session["active_wishlist"] = checkedwishlist;
                    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ModelState.AddModelError("email", "Ingevoerde e-mail bestaat niet.");
                //    return View(wishlist);
                //}
            }
            return View(wishlist);
        }

        public ActionResult NewWishlist()
        {
            if (Session["active_wishlist"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["active_wishlist"] = null;
                return RedirectToAction("Index");
            }
        }
        public ActionResult EditItem(int id)
        {
            return View("EditItem", repository.GetWishlistItem(id));
        }

        [HttpPost]
        public ActionResult EditItem(WishlistItem wishlistItem)
        {
            if (ModelState.IsValid)
            {
                Wishlist wishlist = (Wishlist)Session["active_wishlist"];
                WishlistItem oldWishlistItem = wishlist.wishlistItems.SingleOrDefault(c => c.Id == wishlistItem.Id);
                wishlist.wishlistItems.Remove(oldWishlistItem);
                wishlist.wishlistItems.Add(wishlistItem);
                wishlist.Id++;
                Session["active_wishlist"] = wishlist;

                return RedirectToAction("Index");
            }
            return View(wishlistItem);
        }

        public ActionResult RemoveItem(int id)
        {
            Wishlist wishlist = (Wishlist)Session["active_wishlist"];
            wishlist.wishlistItems.Remove(wishlist.wishlistItems.SingleOrDefault(c => c.Id == id));
            repository.RemoveWishlistItem(repository.GetWishlistItem(id));
            Session["active_wishlist"] = wishlist;
            return RedirectToAction("Index");
        }
    }
}
