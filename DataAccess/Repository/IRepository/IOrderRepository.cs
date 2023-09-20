
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {

        void Update(Order obj);

        bool ExistsBy(Expression<Func<Order, bool>> filter);

    }
}
