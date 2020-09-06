using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Data
{
    public class FakeRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> Restaurants;

        public FakeRestaurantData()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant{Id=1,Name="East Buffet",CType=CuisinType.Chinese},
                new Restaurant{Id=2,Name="Shusi Bar",CType=CuisinType.Japanese},
                new Restaurant{Id=3,Name="Taco Bell",CType=CuisinType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetList(string SearchTerm)
        {
            return Restaurants.Where(r => string.IsNullOrEmpty(SearchTerm)||r.Name.Contains(SearchTerm) );
        }

        public Restaurant GetById(int id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == id);
        }
        public Restaurant update(Restaurant restaurant)
        {
            var rest = Restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
            if (rest != null)
            {
                rest.Name = restaurant.Name;
                rest.CType = restaurant.CType;
            }
            return rest;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(r => r.Id)+1;
            Restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var rest = Restaurants.FirstOrDefault(r => r.Id == id);
            if(rest != null)
            {
                Restaurants.Remove(rest);
            }
            return rest;
        }

        public int GetCount()
        {
            return Restaurants.Count;
        }
    }
}
