using Microsoft.EntityFrameworkCore;

namespace KeithsCoffee.Models
{
  public class KeithsCoffeeContext : DbContext
  {
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<CoffeeShop> CoffeeShops { get; set; }
    public DbSet <CoffeeShopDrink> CoffeeShopDrinks { get; set; }
    
    public KeithsCoffeeContext(DbContextOptions options) : base(options) { }
  }
}