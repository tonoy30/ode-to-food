using System.Collections.Generic;
using FoodService.Core.Models;
using FoodService.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodService.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly RestaurantService _restaurantService;

        [BindProperty(SupportsGet = true)] public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            Restaurants = _restaurantService.Get();
        }
    }
}