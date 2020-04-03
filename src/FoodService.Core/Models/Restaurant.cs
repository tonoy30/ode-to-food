using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodService.Core.Models
{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required, StringLength(80)] public string Name { get; set; }
        [Required, StringLength(280)] public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}