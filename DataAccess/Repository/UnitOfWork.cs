

using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;

namespace ShoppFood.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork

    {

        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IUserRepository User { get; private set; }
        public IRestaurantRepository Restaurant { get; private set; }
        public IBankRepository Bank { get; private set; }
        public IProductRepository Product { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }
    

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           
            Category = new CategoryRepository(_db);
            User = new UserRepository(_db);
            Restaurant = new RestaurantRepository(_db);
            Bank = new BankRepository(_db);
            Product = new ProductRepository(_db);
            ProductImage = new ProductImageRepository(_db);


        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
