
namespace KeithsCoffee.Models
{
  public class CoffeeShop
  {
    public int CoffeeShopId { get; set; }
    
    [Required(ErrorMessage = "The Coffee Shop must have a name!")]
    public string Name { get; set; }

    [Range(1, 5, ErrorMessage "Set your rating between 1-5!")]
    public int Rating { get; set; }

    public bool Unionized { get; set; }

    [Range(1, 5, ErrorMessage "Set your price range between 1-5")] // auto requires something between 1 and 5, so empty would make this unhappy
    public int PriceRange { get; set; }

    // Collection Navigation Property
    public List<CoffeeShopDrink> JoinEntities { get; }
  }
}