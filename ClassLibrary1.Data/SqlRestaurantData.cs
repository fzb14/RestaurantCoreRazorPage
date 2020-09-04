using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
            }
                
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var res = db.Restaurants.FirstOrDefault(r => r.Id == id);
            if (res != null)
            {
                db.Restaurants.Remove(res);
                db.SaveChanges();
            }
            return res;
        }

        public Restaurant GetById(int id)
        {
            var res = db.Restaurants.FirstOrDefault(r => r.Id == id);
            return res;
        }

        public IEnumerable<Restaurant> GetList(string SearchTerm)
        {
            var res = db.Restaurants.Where(r => r.Name.Contains(SearchTerm) || string.IsNullOrEmpty(SearchTerm));
            return res;
        }

        public Restaurant update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return restaurant;
        }
    }
}
