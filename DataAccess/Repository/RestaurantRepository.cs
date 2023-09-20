
using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private ApplicationDbContext _db;
        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool ExistsBy(Expression<Func<Restaurant, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public void Update(Restaurant obj)
        {
            _db.Restaurants.Update(obj);
        }
    }
}
