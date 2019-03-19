using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels.Cart;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly WebShopContext _context;
        private readonly IProduct _productService;
        private readonly ICartItem _cartItemService;
        private readonly ICart _cartService;
        private readonly UserManager<ShopUser> _userManager;

        public CartController(WebShopContext context, IProduct productService, ICartItem cartItemService, ICart cartService, UserManager<ShopUser> userManager)
        {
            _context = context;
            _productService = productService;
            _cartItemService = cartItemService;
            _cartService = cartService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var UserID = _userManager.GetUserId(User);
            IEnumerable<CartListingModel> cartItems = _cartService.GetByUserID(UserID).CartItems.Select(cartItem => new CartListingModel
            {
                ID = cartItem.CartItemID,
                Name = cartItem.Product.Name,
                ImageURL = cartItem.Product.ImageURL,
                Price = cartItem.Product.Price,
                Amount = cartItem.Amount,
                ProductID = cartItem.Product.ID
            });

            CartIndexModel model = new CartIndexModel
            {
                CartItemsList = cartItems
            };

            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _cartItemService.GetByID(id);
            var UserID = _userManager.GetUserId(User);
            _cartService.DeleteItemFromCart(cartItem, UserID);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCartAtAll(int id)
        {
            var cartItem = _cartItemService.GetByID(id);
            var UserID = _userManager.GetUserId(User);
            _cartService.DeleteItemFromCartAtAll(cartItem, UserID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveAllItems()
        {
            var UserID = _userManager.GetUserId(User);
            _cartService.Clear(UserID);
            return RedirectToAction("Index");
        }
    }
}