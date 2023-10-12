using KeithsCoffee.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KeithsCoffee.Controllers
{
  public class HomeController : Controller
  {
    private readonly KeithsCoffeeContext _db;

    public HomeController(KeithsCoffeeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<CoffeeShopDrink> model = _db.CoffeeShopDrinks
                                                        .Include(shopDrink => shopDrink.CoffeeShop)
                                                        .Include(shopDrink => shopDrink.Drink)
                                                        .OrderByDescending(shopDrink => shopDrink.DateOfReview)
                                                        .ToList();
      return View(model);
    }
  }
}