namespace ShoppFood.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IRestaurantRepository Restaurant { get; }
        IBankRepository Bank { get; }
        IProductRepository Product { get; }
        IProductImageRepository ProductImage { get; }
        
        IOrderDetailRepository OrderDetail { get; }
        
        IOrderRepository Order { get; }
        void Save();
    }
}
