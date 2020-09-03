using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Core;
using ClassLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreWebApplication1.Pages.Restaurants
{
    public class editModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> cuisines { get; set; }
        public editModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            cuisines = htmlHelper.GetEnumSelectList<CuisinType>();
            if (id.HasValue)
            {
                Restaurant = restaurantData.GetById(id.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                cuisines = htmlHelper.GetEnumSelectList<CuisinType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                Restaurant = restaurantData.update(Restaurant);
            }
            else
            {
                Restaurant = restaurantData.Add(Restaurant);
            }
            //ViewData["message"] = "ViewData:saved successfully!";
            TempData["Message"] = "TempData:saved successfully!";
            return RedirectToPage("./Detail", new { id = Restaurant.Id });
            //if (Restaurant == null)
            //return RedirectToPage("./NotFound");


        }
    }
}
