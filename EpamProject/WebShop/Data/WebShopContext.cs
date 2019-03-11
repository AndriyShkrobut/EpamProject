using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Models
{
  public class WebShopContext : DbContext
  {
    public WebShopContext(DbContextOptions<WebShopContext> options)
        : base(options)
    {
    }

    public DbSet<WebShop.Models.Product> Product { get; set; }

    public DbSet<WebShop.Models.Cart> Cart { get; set; }
  }
}
