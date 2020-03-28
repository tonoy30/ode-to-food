#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Core.Models;
using FoodService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodService.Web
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty] public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(string restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (!string.IsNullOrEmpty(restaurantId))
            {
                Restaurant = _restaurantData.GetRestaurantsById(restaurantId);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (string.IsNullOrEmpty(Restaurant.Id))
            {
                _restaurantData.Create(Restaurant);
                TempData["Message"] = "Restaurant Added";
            }
            else
            {
                _restaurantData.UpdateRestaurant(Restaurant);
                TempData["Message"] = "Restaurant Updated";
            }

            _restaurantData.Commit();

            return RedirectToPage("./Details", new {restaurantId = Restaurant.Id});
        }
    }
}