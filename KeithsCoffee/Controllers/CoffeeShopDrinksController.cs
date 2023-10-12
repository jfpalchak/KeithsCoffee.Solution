using Microsoft.AspNetCore.Mvc;
using KeithsCoffee.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace KeithsCoffee.Controllers
{
  public class CoffeeShopDrinksController : Controller
  {
    private readonly KeithsCoffeeContext _db;
    public CoffeeShopDrinksController(KeithsCoffeeContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<CoffeeShopDrink> model = _db.CoffeeShopDrinks
                                                        .Include(shopDrink => shopDrink.CoffeeShop)
                                                        .Include(shopDrink => shopDrink.Drink)
                                                        .ToList();
      return View(model);
    }

    public ActionResult AddReview()
    {
      ViewBag.CoffeeShopId = new SelectList(_db.CoffeeShops, "CoffeeShopId", "Name");
      ViewBag.DrinkId = new SelectList(_db.Drinks, "DrinkId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult AddReview (int coffeeShopId, int drinkId, int price, DateTime dateOfReview, string notes, int rating)
    {
      #nullable enable
      CoffeeShopDrink? joinEntity = _db.CoffeeShopDrinks.FirstOrDefault(join => (join.CoffeeShopId == coffeeShopId && join.DrinkId == drinkId));
      #nullable disable
      if (joinEntity == null && coffeeShopId != 0 && drinkId != 0)
      {
        if(!ModelState.IsValid)
        {
          return View();
        }
        _db.CoffeeShopDrinks.Add(new CoffeeShopDrink() { CoffeeShopId = coffeeShopId, DrinkId = drinkId, Price = price, DateOfReview = dateOfReview, Notes = notes, Rating = rating});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      CoffeeShopDrink thisCoffeeShopDrink = _db.CoffeeShopDrinks
                                                      .Include(shopDrink => shopDrink.CoffeeShop)
                                                      .Include(shopDrink => shopDrink.Drink)
                                                      .FirstOrDefault(shopDrink => shopDrink.CoffeeShopDrinkId == id);
      return View(thisCoffeeShopDrink);
    }
  }
}