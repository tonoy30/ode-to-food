using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Core.Models;
using FoodService.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodService.Web.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly RestaurantService _restaurantService;
        public Restaurant Restaurant{ get; set; }
        [TempData]
        public string Message{ get; set; }
        public DetailsModel( RestaurantService restaurantService )
        {
            _restaurantService = restaurantService;
        }

        public IActionResult OnGet(string restaurantId)
        {
           
            Restaurant = _restaurantService.Get(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
