
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository.IRepository
{
    public interface IBankRepository : IRepository<Bank>
    {

        void Update(Bank obj);

        bool ExistsBy(Expression<Func<Bank, bool>> filter);

    }
}
