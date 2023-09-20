
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository.IRepository
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {

        void Update(Restaurant obj);

        bool ExistsBy(Expression<Func<Restaurant, bool>> filter);

    }
}
