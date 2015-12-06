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
            
        }

        public DbSet<ihff.Models.Activiteit> activiteiten { get; set; }
        public DbSet<ihff.Models.WishlistItem> wishlistItems { get; set; }
        public DbSet<ihff.Models.Wishlist> wishlists { get; set; }
    }
}