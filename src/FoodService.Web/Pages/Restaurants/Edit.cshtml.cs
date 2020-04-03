#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Core.Models;
using FoodService.Data;
using FoodService.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodService.Web
{
    public class EditModel : PageModel
    {
        private readonly RestaurantService _restaurantService;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty] public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(RestaurantService restaurantService, IHtmlHelper htmlHelper)
        {
            _restaurantService = restaurantService;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(string restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (!string.IsNullOrEmpty(restaurantId))
            {
                Restaurant = _restaurantService.Get(restaurantId);
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
                _restaurantService.Create(Restaurant);
                TempData["Message"] = "Restaurant Added";
            }
            else
            {
                _restaurantService.Update(Restaurant.Id, Restaurant);
                TempData["Message"] = "Restaurant Updated";
            }

            return RedirectToPage("./Details", new {restaurantId = Restaurant.Id});
        }
    }
}