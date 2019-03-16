using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.ViewModels;
using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using WebShop.Data.Models;

namespace WebShop.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<ShopUser> _userManager;
    private readonly SignInManager<ShopUser> _signInManager;
    public AccountController(UserManager<ShopUser> userManager, SignInManager<ShopUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      ShopUser ShopUser = new ShopUser { Email = model.Email, UserName = model.FullName };
      var result = await _userManager.CreateAsync(ShopUser, model.Password);

      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(ShopUser, false);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }
      return View(model);
    }
  }
}