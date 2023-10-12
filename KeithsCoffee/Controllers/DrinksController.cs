using KeithsCoffee.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KeithsCoffee.Controllers
{
  public class DrinksController : Controller
  {
    private readonly KeithsCoffeeContext _db;

    public DrinksController(KeithsCoffeeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Drink> model = _db.Drinks.ToList();
      return View(model);    
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Drink drink)
    {
      if(!ModelState.IsValid)
      {
        return View(drink);
      }
      _db.Drinks.Add(drink);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Drink thisDrink = _db.Drinks.FirstOrDefault(drink => drink.DrinkId == id);
      return View(thisDrink);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Drink thisDrink = _db.Drinks.FirstOrDefault(drink => drink.DrinkId == id);
      _db.Drinks.Remove(thisDrink);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Drink thisDrink = _db.Drinks.FirstOrDefault(drink => drink.DrinkId == id);
      return View(thisDrink);
    }

    [HttpPost]
    public ActionResult Edit(Drink drink)
    {
      _db.Drinks.Update(drink);
      _db.SaveChanges();
      // return RedirectToAction("Index");
      return RedirectToAction("Details", new { id = drink.DrinkId });
    }

    public ActionResult Details(int id)
    {
      Drink thisDrink = _db.Drinks.Include(drink => drink.JoinEntities).ThenInclude(join => join.CoffeeShop).FirstOrDefault(drink => drink.DrinkId == id);
    return View(thisDrink);
    }
  }
}