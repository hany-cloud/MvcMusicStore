using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        // The declaration of "Artists" is added to allow the Scaffolding feature to build our StoreManagerController
        // with read/write actions and views from the Album model and using our MusicStoreEntities database dbContext class
        // with no errors in building wizard
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}