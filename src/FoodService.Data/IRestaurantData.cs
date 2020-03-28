using System;
using System.Collections.Generic;
using System.Linq;
using FoodService.Core.Models;


namespace FoodService.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantsById(string id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tonoy's Pizza",
                    Location = "Maryland",
                    Cuisine = CuisineType.Indian
                }, new Restaurant()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Cinnamon Club",
                    Location = "London",
                    Cuisine = CuisineType.Mexican
                },
                new Restaurant()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "La Costa",
                    Location = "Utah",
                    Cuisine = CuisineType.Italian
                }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name
                select r;

        }

        public Restaurant GetRestaurantsById(string id)
        {
            return restaurants.FirstOrDefault(item => item.Id == id);

        }
    }
}

