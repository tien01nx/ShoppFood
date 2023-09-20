
using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool ExistsBy(Expression<Func<Product, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
