namespace ShoppFood.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IRestaurantRepository Restaurant { get; }
        IBankRepository Bank { get; }
        IProductRepository Product { get; }
        IProductImageRepository ProductImage { get; }
        void Save();
    }
}
