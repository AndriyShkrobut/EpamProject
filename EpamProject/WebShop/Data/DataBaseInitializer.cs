using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Models;

namespace WebShop.Data
{
  public class DataBaseInitializer
  {
    public static void Initialize(WebShopContext context)
    {
      context.Database.EnsureCreated();

      if (context.Products.Any())
      {
        return;
      }

      var products = new Product[]
      {
        new Product{ Name = "Samsung Galaxy S7", Description = "Powerfull and beautiful smartphone from Samsung", ImageURL = "http://www.stickpng.com/assets/images/58ac4b940aaa10546adf2706.png", Price = 245.99m},
        new Product{ Name = "Samsung Galaxy S7", Description = "Powerfull and beautiful smartphone from Samsung", ImageURL = "http://www.stickpng.com/assets/images/58ac4b940aaa10546adf2706.png", Price = 245.99m},
        new Product{ Name = "Samsung Galaxy S7", Description = "Powerfull and beautiful smartphone from Samsung", ImageURL = "http://www.stickpng.com/assets/images/58ac4b940aaa10546adf2706.png", Price = 245.99m},
        new Product{ Name = "Samsung Galaxy S7", Description = "Powerfull and beautiful smartphone from Samsung", ImageURL = "http://www.stickpng.com/assets/images/58ac4b940aaa10546adf2706.png", Price = 245.99m},
        new Product{ Name = "Samsung Galaxy S7", Description = "Powerfull and beautiful smartphone from Samsung", ImageURL = "http://www.stickpng.com/assets/images/58ac4b940aaa10546adf2706.png", Price = 245.99m},
      };

      foreach (Product product in products)
      {
        context.Add(product);
      }
      context.SaveChanges();
    }
  }
}
