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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetById(id);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Restaurant = restaurantData.GetById(id);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            restaurantData.Delete(id);
            TempData["Message"] = Restaurant.Name + " Delelted!";
            return RedirectToPage("./List");
        }
    }
}
