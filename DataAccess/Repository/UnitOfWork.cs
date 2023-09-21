

using ShoppFood.DataAccess.Data;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

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

        public IOrderRepository Order { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           
            Category = new CategoryRepository(_db);
            User = new UserRepository(_db);
            Restaurant = new RestaurantRepository(_db);
            Bank = new BankRepository(_db);
            Product = new ProductRepository(_db);
            ProductImage = new ProductImageRepository(_db);
            Order = new OrderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);


        }
        
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Category))
                return Category as IRepository<T>;
            else if (typeof(T) == typeof(User))
                return User as IRepository<T>;
            else if (typeof(T) == typeof(Restaurant))
                return Restaurant as IRepository<T>;
            
            else if (typeof(T) == typeof(Bank))
                return Bank as IRepository<T>;
            else if (typeof(T) == typeof(Product))
                return Product as IRepository<T>;
            
            else if (typeof(T) == typeof(Order))
                return Order as IRepository<T>;
            else if (typeof(T) == typeof(OrderDetail))
                return OrderDetail as IRepository<T>;
           
            // bạn có thể trả về một repository chung hoặc null.
            return null;
        }


        public void Save()
        {
            _db.SaveChanges();
        }
        
    }
}
