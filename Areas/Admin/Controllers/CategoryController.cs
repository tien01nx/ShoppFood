using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWord) : base(unitOfWord)
        {
            _unitOfWork = unitOfWord;
        }


   

        [HttpPost]
        public IActionResult Upsert([FromBody] Category category)
        {
            try
            {
                bool exists = _unitOfWork.Category.ExistsBy(u => u.Name.Equals(category.Name));
                if (exists)
                {

                    category.UpdateDate = DateTime.Now;
                    _unitOfWork.Category.Update(category);
                    return Ok(new
                    {
                        message = "Cập nhật thành công"
                    });
                }
                else  if(category.Id==0)
                    _unitOfWork.Category.Add(category);

                
                _unitOfWork.Save();
                
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