using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;

namespace ihff.Controllers
{
    public class FilmsController : Controller
    {
        private DbRepository repository = new DbRepository();

        public ActionResult Index()
        {
            return View(repository.GetAllFilms());
        }

        public ActionResult AddItem(int id)
        {
            Activity activity = repository.GetFilm(id);
            WishlistItem wishlistItem = new WishlistItem();
            
            wishlistItem.name = activity.name;
            wishlistItem.location = activity.location;
            wishlistItem.startTime = activity.startTime;
            wishlistItem.endTime = activity.endTime;
            wishlistItem.actID = activity.Id;
            wishlistItem.persons = null;

            wishlistItem.type = "Film";
            return View(wishlistItem);
            
        }

        [HttpPost]
        public ActionResult AddItem(WishlistItem wishlistItem)
        {
            if (ModelState.IsValid)
            {
                Wishlist wishlist = new Wishlist();

                if (!(Session["active_wishlist"] == null))
                {
                    wishlist = (Wishlist)Session["active_wishlist"];
                    wishlist.wishlistItems.Add(wishlistItem);
                }
                else
                {
                    wishlist.wishlistItems.Add(wishlistItem);
                    Session["active_wishlist"] = wishlist;
                }
                return RedirectToAction("Index", "Wishlist");
            }
            return View(wishlistItem);
            
        }
    }
}
