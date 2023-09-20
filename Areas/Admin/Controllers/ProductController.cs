using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWord)
        {
            _unitOfWork = unitOfWord;
        }
        public IActionResult Index()
        {


            return View();
        }


        public IActionResult GetAllProduct()
        {
            var product = _unitOfWork.Product.GetAll();

            return Json(product);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                return Ok("Thêm thành công");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product != null)
            {
                return Ok(product);
            }

            return BadRequest("Product không tồn tại");

        }


        [HttpPost]
        public IActionResult Edit([FromBody] Product product)
        {

            if (ModelState.IsValid)
            {
                var obj = _unitOfWork.Product.Get(u => u.Id == product.Id);
                if (obj != null)
                {
                    _unitOfWork.Product.Update(product);


                    _unitOfWork.Save();

                    return Ok(product);
                }

               
            }

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product != null)
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                return Ok("Xóa thành công");
            }

            return BadRequest("Product không tồn tại");

        }

    }
}
