using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodService.Core.Models
{
    public class Restaurant
    {
        public string Id { get; set; }
        [Required, StringLength(80)] public string Name { get; set; }
        [Required, StringLength(280)] public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}