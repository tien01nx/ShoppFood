using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;

namespace ShoppFood.Areas.Admin.Controllers
{
    public abstract class BaseController<TEntity> : Controller where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IActionResult GetAll()
        {
            var entities = _unitOfWork.GetRepository<TEntity>().GetAll().ToList();
            return Json(entities);
        }
    }


}
