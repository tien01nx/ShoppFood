using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class RestaurantController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public IActionResult Index()
        { 
            return View();
        }


        public IActionResult GetAllRestaurant()
        {
            var restaurant = _unitOfWork.Restaurant.GetAll();

            return Json(restaurant);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Restaurant restaurant)
        {
            try
            {
                bool exists = _unitOfWork.Restaurant.ExistsBy(c => c.RestaurantName.Equals(restaurant.RestaurantName));
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên  RestaurantName đã tồn tại"
                    });
                }
                else
                {
                    restaurant.onCreate();
                    // sau sua thanh bang thiet bi dang dang nhap
                    restaurant.CreateBy = "hehe";
                  
                    restaurant.UpdateBy = "hehe";
                    _unitOfWork.Restaurant.Add(restaurant);
                    _unitOfWork.Save();
                }


                return Ok(restaurant);
            }
            catch
            {
                return BadRequest("Thêm không thành công");
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

        [HttpPost]
        public IActionResult Edit([FromBody]Restaurant restaurant)
        {

            try
            {
                bool exists = _unitOfWork.Restaurant.ExistsBy(c => c.RestaurantName.Equals(restaurant.RestaurantName));
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên  RestaurantName đã tồn tại"
                    });
                }
                else
                {
                    restaurant.onUpdate();

                    // sau sửa thành người dùng đang nhăp nhập
                    restaurant.UpdateBy = "hehe";
                    _unitOfWork.Restaurant.Update(restaurant);
                    _unitOfWork.Save();
                }


                return Ok(restaurant);
            }
            catch
            {
                return BadRequest("Thêm không thành công");
            }


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
