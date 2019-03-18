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
        private readonly IShopUser _userService;

        public CartService(WebShopContext context, IShopUser userService)
        {
            _context = context;
            _userService = userService;
        }

        public CartService(WebShopContext context)
        {
            _context = context;
        }

        public Cart GetByID(int id)
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
            return _context.Carts.Where(cart => cart.ShopUser.Id == id)
                .Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                .SingleOrDefault();
        }

        public async Task Add(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
        }

        public async Task AddItemToCart(Product product, string id)
        {
            var user = _userService.GetById(id);

            var cart = GetByUserID(id);
            if (cart == null)
            {
                _context.Carts.Add(new Cart { ShopUser = user });
                _context.SaveChanges();
            }
            cart = GetByUserID(id);

            var shoppingCartItem = _context.CartItems.SingleOrDefault(ci => ci.Product.ID == product.ID && ci.CartID == cart.CartID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new CartItem
                {
                    CartID = cart.CartID,
                    Product = product,
                    Amount = 1,
                    Total = product.Price
                };

                await AddCartItem(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public async Task Delete(int id)
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
