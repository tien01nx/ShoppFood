
using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;
using System.Linq.Expressions;

namespace ShoppFood.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool ExistsBy(Expression<Func<User, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
    }
}
