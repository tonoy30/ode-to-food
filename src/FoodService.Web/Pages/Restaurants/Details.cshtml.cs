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
        [TempData]
        public string Message{ get; set; }
        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(string restaurantId)
        {
            Console.WriteLine(_restaurantData.GetRestaurantsById(restaurantId));
            Restaurant = _restaurantData.GetRestaurantsById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
