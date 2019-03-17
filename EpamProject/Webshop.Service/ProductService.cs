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

        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task AddToCart(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int productID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetByID(int id)
        {
            var product = _context.Products.Where(p => p.ID == id).FirstOrDefault();
            return product;
        }
    }
}
