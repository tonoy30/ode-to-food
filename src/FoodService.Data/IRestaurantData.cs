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
        Restaurant UpdateRestaurant(Restaurant restaurant);
        Restaurant Create(Restaurant restaurant);
        int Commit();
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
            return restaurants.SingleOrDefault(item => item.Id == id);

        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var result = restaurants.SingleOrDefault(item => item.Id == restaurant.Id);
            if (result != null)
            {
                result.Name = restaurant.Name;
                result.Location = restaurant.Location;
                result.Cuisine = restaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Create(Restaurant restaurant)
        {
           
           restaurants.Add(restaurant);
           restaurant.Id = Guid.NewGuid().ToString();
           return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}

