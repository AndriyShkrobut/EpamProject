using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<ShopUser> _userManager;

        public CartController(WebShopContext context, IProduct productService, ICart cartService, UserManager<ShopUser> userManager)
        {
            _context = context;
            _productService = productService;
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var currentUser = User;
            var UserID = _userManager.GetUserId(User);
            if (User.Identity.IsAuthenticated)
            {
                IEnumerable<CartListingModel> cartItems = _cartService.GetItems(UserID).Select(cartItem => new CartListingModel
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

                return View(model);
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }

        }


        //[HttpPost]
        //public IActionResult Add(int id)
        //{

        //}
    }
}