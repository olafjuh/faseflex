using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;

namespace ihff.Controllers
{
    public class WishlistController : Controller
    {
        private DbRepository repository = new DbRepository();

        public ActionResult Index()
        {
            IEnumerable<Wishlist> wishlists = repository.GetAllWishlists();
            return View(repository.GetAllItems(wishlists.First()));
        }

    }
}
