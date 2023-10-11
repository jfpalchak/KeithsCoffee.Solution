using System.Collections.Generic;
using System;
// using System.ComponentModel.DataAnnotations;


namespace KeithsCoffee.Models
{
  public class CoffeeShopDrink
  {
    public int CoffeeShopDrinkId { get; set; }
    public CoffeeShop CoffeeShop { get; set; }
    public int CoffeeShopId { get; set; }
    public int DrinkId { get; set; }
    public Drink Drink { get; set; }

    public DateTime DateOfReview { get; set; }
    //re add nullable type my dude?

    public string Notes { get; set; }

    // [Range(1, 5, ErrorMessage = "Set your price range between 1-5")]
    public int Price { get; set; }
  }
}