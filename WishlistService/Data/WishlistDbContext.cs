using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WishlistService.Models;

namespace WishlistService.Data
{
    public class WishlistDbContext : DbContext
    {
        public WishlistDbContext(DbContextOptions<WishlistDbContext> options) : base(options) { }

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}
