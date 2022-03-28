using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContextFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {
        public OdeToFoodDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=OdeToFood;Integrated Security=True");

            return new OdeToFoodDbContext(optionsBuilder.Options);
        }
    }
}
