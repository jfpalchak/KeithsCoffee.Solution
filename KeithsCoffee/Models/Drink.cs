using KeithsCoffee.Models;

namespace KeithsCoffee.Models
{
  public class Drink
  {
    public int DrinkId { get; set; }
    [Required(ErrorMessage = "* The drink must have a name!")]
    public string Name { get; set; }
    
    public List<CoffeeShopDrink> JoinEntities { get; set; }
  }
}