using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels.Product;

namespace WebShop.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProduct _productService;
    private readonly WebShopContext _context;

    public ProductController(IProduct productService, WebShopContext context)
    {
      _productService = productService;
      _context = context;
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