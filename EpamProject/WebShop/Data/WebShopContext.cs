using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebShop.Models
{
  public class WebShopContext : IdentityDbContext<User>
  {
    public WebShopContext(DbContextOptions<WebShopContext> options)
        : base(options)
    {
      //Database.EnsureCreated();
    }

    public DbSet<WebShop.Models.Product> Product { get; set; }

    public DbSet<WebShop.Models.OrderItem> OrderItem { get; set; }
  }
}
