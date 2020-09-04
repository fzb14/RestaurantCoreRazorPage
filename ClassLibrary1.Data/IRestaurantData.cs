using ClassLibrary1.Core;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ClassLibrary1.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetList(string SearchTerm);
        public Restaurant GetById(int id);
        public Restaurant update(Restaurant restaurant);
        public Restaurant Add(Restaurant restaurant);
        public Restaurant Delete(int id);
    }
}
