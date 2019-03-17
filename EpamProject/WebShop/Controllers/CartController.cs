using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ICart _cartService;

        public CartController(WebShopContext context, IProduct productService, ICart cartService)
        {
            _context = context;
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            IEnumerable<CartListingModel> cartItems = _cartService.GetItems().Select(cartItem => new CartListingModel
            {
                ID = cartItem.CartItemID,
                Name = cartItem.Product.Name,
                ImageURL = cartItem.Product.ImageURL,
                Price = cartItem.Product.Price,
                Amount = cartItem.Amount
            });

            CartIndexModel model = new CartIndexModel
            {
                CartItemsList = cartItems
            };

            return View(cartItems.ToList());
        }



        public IActionResult Add(int id)
        {
            var product = _productService.GetByID(id);
            //var cart = _cartService.GetByID(id);

            if (product != null)
            {
                _cartService.AddItem(product, 1);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}