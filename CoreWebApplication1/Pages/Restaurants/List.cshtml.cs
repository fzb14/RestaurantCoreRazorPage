using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Core;
using ClassLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWebApplication1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,IRestaurantData restaurantData,ILogger<ListModel> logger)
        {
            this.config = configuration;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
        public void OnGet(string SearchTerm)
        {
            //this.SearchTerm = SearchTerm;
            //Message = config["error"];
            logger.LogInformation("inside Restaurant list OnGet");
            Restaurants = restaurantData.GetList(SearchTerm);
        }
    }
}
