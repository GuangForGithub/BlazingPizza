using BlazingPizza.Model;

namespace BlazingPizza.Data;

public static class SeedData
{
	public static void InitializePizzaSpecial(PizzaStoreContext psdb)
	{
		var specials = new PizzaSpecial[]
		{
			 new PizzaSpecial()
			{
					Id = 1,
					Name = "Basic Cheese Pizza",
					Description = "It's cheesy and delicious. Why wouldn't you want one?",
					BasePrice = 9.99m,
					ImageUrl = "img/pizzas/cheese.jpg",
			},
			new PizzaSpecial()
			{
					Id = 2,
					Name = "The Baconatorizor",
					Description = "It has EVERY kind of bacon",
					BasePrice = 11.99m,
					ImageUrl = "img/pizzas/bacon.jpg",
			},
			new PizzaSpecial()
			{
					Id = 3,
					Name = "Classic pepperoni",
					Description = "It's the pizza you grew up with, but Blazing hot!",
					BasePrice = 10.50m,
					ImageUrl = "img/pizzas/pepperoni.jpg",
			},
			new PizzaSpecial()
			{
					Id = 4,
					Name = "Buffalo chicken",
					Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
					BasePrice = 12.75m,
					ImageUrl = "img/pizzas/meaty.jpg",
			},
			new PizzaSpecial()
			{
					Id = 5,
					Name = "Mushroom Lovers",
					Description = "It has mushrooms. Isn't that obvious?",
					BasePrice = 11.00m,
					ImageUrl = "img/pizzas/mushroom.jpg",
			},
			new PizzaSpecial()
			{
					Id = 7,
					Name = "Veggie Delight",
					Description = "It's like salad, but on a pizza",
					BasePrice = 11.50m,
					ImageUrl = "img/pizzas/salad.jpg",
			},
			new PizzaSpecial()
			{
					Id = 8,
					Name = "Margherita",
					Description = "Traditional Italian pizza with tomatoes and basil",
					BasePrice = 9.99m,
					ImageUrl = "img/pizzas/margherita.jpg",
			},
		};
		psdb.Specials.AddRange(specials);
		var pizzas = new List<Pizza>
		{
			new Pizza {
				Name = "The Baconatorizor",
				Price = 11.99M,
				Description = "It has EVERY kind of bacon",
				SpecialId = 2,
				Special = specials.Single(special=>special.Id==2),
				Toppings = null,
			},
			new Pizza {
				Name = "Buffalo chicken",
				Price = 12.75M,
				Description = "Spicy chicken, hot sauce, and blue cheese, guaranteed to warm you up",
				SpecialId = 4,
				Special = specials.Single(special=>special.Id==4),
				Toppings = null,
			},
			new Pizza {
				Name = "Veggie Delight",
				Price = 11.5M,
				Description = "It's like salad, but on a pizza",
				SpecialId = 7,
				Special = specials.Single(special=>special.Id==7),
				Toppings = null,
			},
			new Pizza {
				Name = "Margherita",
				Price = 9.99M,
				Description = "Traditional Italian pizza with tomatoes and basil",
				SpecialId = 8,
				Special = specials.Single(special=>special.Id==8),
				Toppings = null,
			},
			new Pizza {
				Name = "Basic Cheese Pizza",
				Price = 11.99M,
				Description = "It's cheesy and delicious. Why wouldn't you want one?",
				SpecialId = 1,
				Special = specials.Single(special=>special.Id==1),
				Toppings = null,
			},
			new Pizza {
				Name = "Classic pepperoni",
				Price = 10.5M,
				Description = "It's the pizza you grew up with, but Blazing hot!",
				SpecialId = 3,
				Special = specials.Single(special=>special.Id==3),
				Toppings = null,
			}
		};
		psdb.Pizzas.AddRange(pizzas);
		psdb.SaveChanges();
	}
}