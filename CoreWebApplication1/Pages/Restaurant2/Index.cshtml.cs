﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Core;
using ClassLibrary1.Data;

namespace CoreWebApplication1.Pages.Restaurant2
{
    public class IndexModel : PageModel
    {
        private readonly ClassLibrary1.Data.RestaurantDbContext _context;

        public IndexModel(ClassLibrary1.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
