//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using WebShop.Data.Models;

//namespace WebShop.Controllers
//{
//  public class OrderItemsController : Controller
//  {
//    private readonly WebShopContext _context;

//    public OrderItemsController(WebShopContext context)
//    {
//      _context = context;
//    }

//    // GET: OrderItems
//    public async Task<IActionResult> Index()
//    {
//      var webShopContext = _context.OrderItem.Include(o => o.Order).Include(o => o.Product);
//      return View(await webShopContext.ToListAsync());
//    }

//    // GET: OrderItems/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//      if (id == null)
//      {
//        return NotFound();
//      }

//      var orderItem = await _context.OrderItem
//          .Include(o => o.Order)
//          .Include(o => o.Product)
//          .FirstOrDefaultAsync(m => m.OrderItemID == id);
//      if (orderItem == null)
//      {
//        return NotFound();
//      }
//      return View(orderItem);
//    }

//    // GET: OrderItems/Create
//    public IActionResult Create()
//    {
//      ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID");
//      ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID");
//      return View();
//    }

//    // POST: OrderItems/Create
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("OrderItemID,OrderID,ProductID,Amount")] OrderItem orderItem)
//    {
//      if (ModelState.IsValid)
//      {
//        _context.Add(orderItem);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//      }
//      ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID", orderItem.OrderID);
//      ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID", orderItem.ProductID);
//      return View(orderItem);
//    }

//    // GET: OrderItems/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//      if (id == null)
//      {
//        return NotFound();
//      }

//      var orderItem = await _context.OrderItem.FindAsync(id);
//      if (orderItem == null)
//      {
//        return NotFound();
//      }
//      ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID", orderItem.OrderID);
//      ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID", orderItem.ProductID);
//      return View(orderItem);
//    }

//    // POST: OrderItems/Edit/5
//    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("OrderItemID,OrderID,ProductID,Amount")] OrderItem orderItem)
//    {
//      if (id != orderItem.OrderItemID)
//      {
//        return NotFound();
//      }

//      if (ModelState.IsValid)
//      {
//        try
//        {
//          _context.Update(orderItem);
//          await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//          if (!OrderItemExists(orderItem.OrderItemID))
//          {
//            return NotFound();
//          }
//          else
//          {
//            throw;
//          }
//        }
//        return RedirectToAction(nameof(Index));
//      }
//      ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID", orderItem.OrderID);
//      ViewData["ProductID"] = new SelectList(_context.Product, "ID", "ID", orderItem.ProductID);
//      return View(orderItem);
//    }

//    // GET: OrderItems/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//      if (id == null)
//      {
//        return NotFound();
//      }

//      var orderItem = await _context.OrderItem
//          .Include(o => o.Order)
//          .Include(o => o.Product)
//          .FirstOrDefaultAsync(m => m.OrderItemID == id);
//      if (orderItem == null)
//      {
//        return NotFound();
//      }

//      return View(orderItem);
//    }

//    // POST: OrderItems/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//      var orderItem = await _context.OrderItem.FindAsync(id);
//      _context.OrderItem.Remove(orderItem);
//      await _context.SaveChangesAsync();
//      return RedirectToAction(nameof(Index));
//    }

//    private bool OrderItemExists(int id)
//    {
//      return _context.OrderItem.Any(e => e.OrderItemID == id);
//    }
//  }
//}
