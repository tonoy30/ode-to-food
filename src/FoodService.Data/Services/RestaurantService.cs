using System;
using System.Collections.Generic;
using FoodService.Core.Models;
using FoodService.Data.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FoodService.Data.Services
{
    public class RestaurantService
    {
        private readonly IMongoCollection<Restaurant> _restaurant;

        public RestaurantService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _restaurant = database.GetCollection<Restaurant>(settings.CollectionName);
        }

        public List<Restaurant> Get()
        {
            return _restaurant.Find(restaurant => true).ToList();
        }

        public Restaurant Get(string id) =>
            _restaurant.Find<Restaurant>(restaurant => restaurant.Id == id).FirstOrDefault();

        public List<Restaurant> GetByName(string name)
        {
            var filter = new BsonDocument("Name", new BsonDocument("$regex", name.ToLower()));
            return _restaurant.Find(filter).ToList();
        }


        public Restaurant Create(Restaurant restaurant)
        {
            _restaurant.InsertOne(restaurant);
            return restaurant;
        }

        public void Update(string id, Restaurant restaurantIn) =>
            _restaurant.ReplaceOne(restaurant => restaurant.Id == id, restaurantIn);


        public void Remove(string id) => _restaurant.DeleteOne(restaurant => restaurant.Id == id);
    }
}