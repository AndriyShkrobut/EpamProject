using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
  public class ProductsController : Controller
  {
    private readonly WebShopContext _context;

    public ProductsController(WebShopContext context)
    {
      _context = context;
    }

    // GET: Products
    public async Task<IActionResult> Index(string searchText)
    {
      ViewData["CurrentFilter"] = searchText;

      var products = from s in _context.Product select s;

      if (!String.IsNullOrEmpty(searchText))
      {
        products = products.Where(s => s.Name.Contains(searchText) || s.Description.Contains(searchText));
      }

      return View(await products.AsNoTracking().ToListAsync());
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Product
          .FirstOrDefaultAsync(m => m.Id == id);

      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(/*[Bind("Id,Name,Description,Image,Price")] */Product product)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(product);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
      }
      catch (DbUpdateException exception)
      {
        ModelState.AddModelError(exception.Message, "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "see your system administrator.");
      }
      return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Product.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPost(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var productToUpdate = await _context.Product.SingleOrDefaultAsync(s => s.Id == id);
      if (await TryUpdateModelAsync<Product>(productToUpdate, "", s => s.Name, s => s.Description, s => s.Image, s => s.Price))
      {
        try
        {
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException exception)
        {
          //Log the error (uncomment ex variable name and write a log.)
          ModelState.AddModelError(exception.Message, "Unable to save changes. " +
              "Try again, and if the problem persists, " +
              "see your system administrator.");
        }
      }
      return View(productToUpdate);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
      if (id == null)
      {
        return NotFound();
      }

      var product = await _context.Product
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

      if (product == null)
      {
        return NotFound();
      }

      if (saveChangesError.GetValueOrDefault())
      {
        ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " + "see your system administrator.";
      }

      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var product = await _context.Product
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

      if (product == null)
      {
        return RedirectToAction(nameof(Index));
      }

      try
      {
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      catch (DbUpdateException exception)
      {
        ModelState.AddModelError(exception.Message, "Unable to save changes. " + "Try again, and if the problem persists, " + "see your system administrator.");
        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
      }
    }

    private bool ProductExists(int id)
    {
      return _context.Product.Any(e => e.Id == id);
    }
  }
}
