using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Data
{
    public class ShopCoreDbContext : DbContext
    {
        public ShopCoreDbContext(DbContextOptions<ShopCoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
