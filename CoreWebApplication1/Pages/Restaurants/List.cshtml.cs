using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Core;
using ClassLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CoreWebApplication1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,IRestaurantData restaurantData)
        {
            this.config = configuration;
            this.restaurantData = restaurantData;
        }
        public void OnGet(string SearchTerm)
        {
            //this.SearchTerm = SearchTerm;
            //Message = config["error"];

            Restaurants = restaurantData.GetList(SearchTerm);
        }
    }
}
