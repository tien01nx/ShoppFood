
using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool ExistsBy(Expression<Func<Category, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
