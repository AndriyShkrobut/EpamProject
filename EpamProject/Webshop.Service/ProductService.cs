using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace Webshop.Service
{
    public class ProductService : IProduct
    {
        private readonly WebShopContext _context;

        public ProductService(WebShopContext context)
        {
            _context = context;
        }

        public Product GetByID(int id)
        {
            var product = _context.Products.Where(p => p.ID == id).FirstOrDefault();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }


        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = GetByID(id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
