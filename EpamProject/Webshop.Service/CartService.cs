using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace Webshop.Service
{
    public class CartService : ICart
    {
        private readonly WebShopContext _context;

        public CartService(WebShopContext context)
        {
            _context = context;
        }

        public Cart GetByID(int id)
        {
            var cart = _context.Carts.Where(c => c.CartID == id)
                .Include(c => c.CartItems).ThenInclude(p => p.Product)
                .Include(c => c.ShopUser)
                .FirstOrDefault();
            return cart;
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _context.CartItems;
        }

        public void AddItem(Product product, int amount)
        {
            var cartItem = _context.CartItems.SingleOrDefault(ci => ci.Product.ID == product.ID);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Product = product,
                    Amount = 1,
                    Total = product.Price
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public Task Clear()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItem()
        {
            throw new System.NotImplementedException();
        }

        public Task GetTotal()
        {
            throw new System.NotImplementedException();
        }
    }
}
