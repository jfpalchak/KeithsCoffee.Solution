using KeithsCoffee.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KeithsCoffee.Controllers
{
  public class CoffeeShopsController : Controller
  {
    private readonly KeithsCoffeeContext _db;

    public CoffeeShopsContoller(KeithsCoffeeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(CoffeeShop coffeeShop)
    {
      if (!ModelState.IsValid) // does the input adhere to the model's data annotations?
      {
        return View(coffeeShop); // display validation messages
      }
      _db.CoffeeShops.Add(coffeeShop);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home") //redirect to home page???????
    }

  }
}