using ClassLibrary1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options):base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
