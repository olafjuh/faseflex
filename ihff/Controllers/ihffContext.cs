using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ihff.Controllers
{
    public class ihffContext : DbContext
    {
         public ihffContext()
            : base("ihffTestConnection")
        {
            Database.SetInitializer<ihffContext>(null);
        }

        public DbSet<ihff.Models.Activities> Activities{ get; set; }
        public DbSet<ihff.Models.WishlistItem> WishlistItems { get; set; }
        public DbSet<ihff.Models.Wishlist> Wishlists { get; set; }
    }
}