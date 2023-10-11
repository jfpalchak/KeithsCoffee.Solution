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
  }
}