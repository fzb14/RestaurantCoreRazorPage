using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary1.Core;
using ClassLibrary1.Data;

namespace CoreWebApplication1.Pages.Restaurant2
{
    public class CreateModel : PageModel
    {
        private readonly ClassLibrary1.Data.RestaurantDbContext _context;
        private readonly IHtmlHelper _htmlHelper;
        public CreateModel(ClassLibrary1.Data.RestaurantDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisinType>();
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
