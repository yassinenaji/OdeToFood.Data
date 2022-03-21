using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {

        public IEnumerable<Restaurant> GetAll();
        public IEnumerable<Restaurant> GetRestaurantByName(string name);
    }
    public class InMemoryRestaurantDataImp : IRestaurantData
    {
         
        private readonly List<Restaurant> _restaurants;
        public InMemoryRestaurantDataImp()
        {
            _restaurants = new List<Restaurant>(){

             new Restaurant{Id=1,Name="Pene Pene Restaurant",Location="Tanger",Cuisine=Restaurant.CuisineType.Italian},
             new Restaurant{Id=2,Name="Indian paprika Restaurant",Location="Casablanca",Cuisine=Restaurant.CuisineType.Indian},
             new Restaurant{Id=3,Name="Tajin City",Location="Tanger",Cuisine=Restaurant.CuisineType.Moroccan}

        };
              


        }

        public IEnumerable<Restaurant> GetAll()
        {
          return from r in _restaurants orderby r.Cuisine select r;
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string? name)
        {
            return from r in _restaurants
                   where r.Name == name
                   orderby r.Cuisine select r;
        }

    }
}
