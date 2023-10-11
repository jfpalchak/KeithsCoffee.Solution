using KeithsCoffee.Models;
using System.Collections.Generic;
using System;

namespace KeithsCoffee.Models
{
  public class CoffeeShopDrink
  {
    public int CoffeeShopDrinkId { get; set; }

    public int CoffeeShopId { get; set; }

    public DateTime? DateOfReview { get; set; }

    public string Notes { get; set; }
    
    [Range(1, 5, ErrorMessage "Set your price range between 1-5")]
    public int Price { get; set; }
  }
}