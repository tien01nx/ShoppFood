using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWord)
        {
            _unitOfWork = unitOfWord;
        }
        public IActionResult Index()
        {


            return View();
        }


        public IActionResult GetAllCategory()
        {
            var category = _unitOfWork.Category.GetAll();

            return Json(category);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                bool exists = _unitOfWork.Category.ExistsBy(u =>u.Name.Equals(category.Name));
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên  danh mục đã tồn tại"
                    });
                }
                else
                {
                    category.onCreate();
                    category.CreateBy = "hehe";
                    // sau sua thanh bang thiet bi dang dang nhap
                    category.UpdateBy = "hehe";
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                }


                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest("Category không tồn tại");

        }


        [HttpPost]
        public IActionResult Edit([FromBody] Category category)
        {

            if (ModelState.IsValid)
            {
                var obj = _unitOfWork.Category.Get(u => u.Id == category.Id);
                if (obj != null)
                {

                    category.onUpdate();

                    // sau sửa thành người dùng đang nhăp nhập
                    category.UpdateBy = "hehe";
                    _unitOfWork.Category.Update(category);


                    _unitOfWork.Save();

                    return Ok(category);
                }

               
            }

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category != null)
            {
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
                return Ok("Xóa thành công");
            }

            return BadRequest("Category không tồn tại");

        }

    }
}
