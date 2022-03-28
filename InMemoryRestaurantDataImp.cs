using OdeToFood.Core;

namespace OdeToFood.Data
{
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

        public IEnumerable<Restaurant> Get_restaurants()
        {
            return _restaurants;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var r = _restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
            if (r != null)
            {
                r.Name = restaurant.Name;  
                r.Location = restaurant.Location;
                r.Cuisine = restaurant.Cuisine;
            }
            return r;
        }

        public int commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
            restaurant.Id=_restaurants.Max(r => r.Id) + 1;
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var r = _restaurants.SingleOrDefault(r => r.Id == id);
            if (r != null)
            {
                _restaurants.Remove(r);
            }
            return r;

        }
    }
}
