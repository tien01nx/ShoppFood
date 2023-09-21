using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class RestaurantController : BaseController<Restaurant>
    {

        private readonly IUnitOfWork _unitOfWork;

     

        public RestaurantController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public IActionResult Upsert([FromBody] Restaurant restaurant)
        {
            try
            {
                bool exists = _unitOfWork.Restaurant.ExistsBy(c => c.RestaurantName.Equals(restaurant.RestaurantName));
                
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên Username đã tồn tại. Vui lòng chọn tên đăng nhập khác."
                    });
                }

              
                if (restaurant.Id == 0)
                {
                    _unitOfWork.Restaurant.Add(restaurant);
                    _unitOfWork.Save();
                    return Ok(new
                    {
                        message = "Thêm người dùng thành công.",
                        user = restaurant
                    });
                }
                else
                {
                    restaurant.UpdateDate = DateTime.Now;
                    _unitOfWork.Restaurant.Update(restaurant);
                    _unitOfWork.Save();
                    return Ok(new
                    {
                        message = "Cập nhật người dùng thành công.",
                        user = restaurant
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Đã xảy ra lỗi. Vui lòng thử lại sau."
                });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var Restaurant = _unitOfWork.Restaurant.Get(u=>u.Id == id); 

            if(Restaurant != null)
            {
                return Ok(Restaurant);
            }
            return BadRequest("Không có nhà hàng");

         
        }
        

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var restaurant  = _unitOfWork.Restaurant.Get(u=>u.Id==id);
            if(restaurant != null)
            {
                _unitOfWork.Restaurant.Remove(restaurant);
                return Ok("Xoa thanh cong");
            }

            return BadRequest("Id tim khong co");
        }

     


    }
}
