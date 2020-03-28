using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Core.Models;
using FoodService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodService.Web.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant{ get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public void OnGet(string restaurantId)
        {
            Console.WriteLine(_restaurantData.GetRestaurantsById(restaurantId));
            Restaurant = _restaurantData.GetRestaurantsById(restaurantId);
        }
    }
}
