using Microsoft.EntityFrameworkCore;
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
        public Restaurant GetById(int id);
        public Restaurant Update(Restaurant restaurant);
        public Restaurant Add(Restaurant restaurant);
        public Restaurant Delete(int id);   
        int commit();
    }

    public class SqlRestauraantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;
        public SqlRestauraantData(OdeToFoodDbContext db)
        {
            this.db = db;   

        }
        public Restaurant Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = db.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant != null)
            db.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
           var query = from r in db.Restaurants
                       where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                       orderby r.Name
                       select r;
            return query;
      
        }

        public Restaurant Update(Restaurant restaurant)
        {
           
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;

        }
    }
}
