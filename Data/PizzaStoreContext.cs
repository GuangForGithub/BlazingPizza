using BlazingPizza.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Data
{
	public class PizzaStoreContext : DbContext
	{
		public PizzaStoreContext(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<PizzaSpecial> Specials { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
	}
}
