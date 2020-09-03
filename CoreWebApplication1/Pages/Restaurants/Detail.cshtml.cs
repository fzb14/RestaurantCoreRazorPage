using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Core;
using ClassLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApplication1.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
