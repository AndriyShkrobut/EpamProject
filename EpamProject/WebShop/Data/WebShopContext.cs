using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Data
{
  public class WebShopContext : DbContext
  {
    public WebShopContext(DbContextOptions<WebShopContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Cart> Cart { get; set; }
  }
}
