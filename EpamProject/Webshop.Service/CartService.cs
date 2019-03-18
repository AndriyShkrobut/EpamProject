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
        //private readonly 

        public CartService(WebShopContext context)
        {
            _context = context;
        }

        public Cart GetByID(string id)
        {
            return _context.Carts.Where(cart => cart.CartID == id)
                .Include(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .Include(cart => cart.ShopUser)
                .FirstOrDefault();
        }

        public IEnumerable<Cart> GetAll()
        {
            return _context.Carts
                .Include(cart => cart.CartItems).ThenInclude(cartItem => cartItem.Product)
                .Include(cart => cart.ShopUser);
        }

        public IEnumerable<CartItem> GetItems(string id)
        {
            return _context.CartItems.Where(cartItem => cartItem.Cart.ShopUser.Id == id);
        }

        public Cart GetByUserID(string id)
        {
            return _context.Carts.Where(cart => cart.ShopUser.Id == id).SingleOrDefault();
        }

        public async Task Add(Cart cart)
        {
            _context.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
        }

        public Task AddItemToCart(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id)
        {
            var cart = GetByID(id);
            _context.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public Task Clear()
        {
            throw new System.NotImplementedException();
        }

        public Task GetTotal()
        {
            throw new System.NotImplementedException();
        }
    }
}
