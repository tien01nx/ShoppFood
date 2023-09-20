using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class BankController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult GetAllBanks()
        {
            var banks = _unitOfWork.Bank.GetAll();
             return Json(banks);
        }

    
    }
}
