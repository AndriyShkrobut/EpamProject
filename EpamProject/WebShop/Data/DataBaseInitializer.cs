using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data
{
  public class DataBaseInitializer
  {
    public static void Initialize(WebShopContext context)
    {
      context.Database.EnsureCreated();

      if (context.Product.Any())
      {
        return;
      }

      var products = new Product[]
      {
        new Product{ Name = "Product1", Description = "Description1", Image = "http://vologdatur.ru/wp-content/uploads/Product_Icon.png", Price = 1.99M },
        new Product{ Name = "Product2", Description = "Description2", Image = "http://vologdatur.ru/wp-content/uploads/Product_Icon.png", Price = 1.99M },
        new Product{ Name = "Product3", Description = "Description3", Image = "http://vologdatur.ru/wp-content/uploads/Product_Icon.png", Price = 1.99M },
        new Product{ Name = "Product4", Description = "Description4", Image = "http://vologdatur.ru/wp-content/uploads/Product_Icon.png", Price = 1.99M },
        new Product{ Name = "Product5", Description = "Description5", Image = "http://vologdatur.ru/wp-content/uploads/Product_Icon.png", Price = 1.99M },
      };

      foreach (Product product in products)
      {
        context.Add(product);
      }
      context.SaveChanges();
    }
  }
}
