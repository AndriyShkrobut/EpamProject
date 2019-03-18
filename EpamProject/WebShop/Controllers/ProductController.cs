using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels.Cart;
using WebShop.ViewModels.Product;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebShopContext _context;
        private readonly IProduct _productService;
        private readonly ICart _cartService;

        private static UserManager<ShopUser> _userManager;

        public ProductController(WebShopContext context, IProduct productService, ICart cartService, UserManager<ShopUser> userManager)
        {
            _context = context;
            _productService = productService;
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductListingModel> products = _productService.GetAll().Select(product => new ProductListingModel
            {
                ID = product.ID,
                Name = product.Name,
                ImageURL = product.ImageURL,
                Price = product.Price
            });

            ProductIndexModel model = new ProductIndexModel
            {
                ProductList = products
            };

            return View(model);
        }

        //[HttpGet]
        //public IActionResult AddToCart(int id)
        //{
        //    //var product = _productService.GetByID(id);
        //    //var cartItem = new CartItem
        //    //{
        //    //    Product = product,
        //    //    Amount = 1,
        //    //};
        //    //return View();
        //    var product = _productService.GetByID(id);
        //    IEnumerable<ProductListingModel> selectedProducts = _productService.GetAll().Select(selProduct => new ProductListingModel
        //    {
        //        ID = product.ID,
        //        Name = product.Name,
        //        ImageURL = product.ImageURL,
        //        Price = product.Price
        //    });
        //    ProductIndexModel model = new ProductIndexModel
        //    {
        //        ProductList = selectedProducts
        //    };


        //    return View("Index");
        //}


        [HttpPost, ActionName("AddToCart")]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCartPost(int id)
        {

            var product = _productService.GetByID(id);
            //var cartItem = new CartItem
            //{
            //    Product = product,
            //    Amount = 1,
            //};
            //return View();
            return View("Index", "Cart");
        }

        //[HttpPost]
        //public IActionResult AddToCart()
        //{
        //    //var UserID = _userManager.GetUserId(User);
        //    //var product = _productService.GetByID(id);
        //    //if(product!= null)
        //    //{
        //    //    var ci = new CartItem
        //    //    {

        //    //    }
        //    //    var cartItem = new CartListingModel
        //    //    {
        //    //        Name = product.Name,
        //    //        ImageURL = product.ImageURL,
        //    //        Price = product.Price,
        //    //        Amount = 1
        //    //    };

        //    //}
        //    return View("Index");
        //}

        public IActionResult Details(int id)
        {
            var product = _productService.GetByID(id);

            var model = new ProductDetailModel
            {
                ID = product.ID,
                Name = product.Name,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Description = product.Description
            };
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}