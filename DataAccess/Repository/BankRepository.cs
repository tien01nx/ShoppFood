
using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private ApplicationDbContext _db;
        public BankRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool ExistsBy(Expression<Func<Bank, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public void Update(Bank obj)
        {
            _db.Banks.Update(obj);
        }
    }
}
