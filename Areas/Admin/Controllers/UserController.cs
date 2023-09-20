using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            var users = _unitOfWork.User.GetAll().ToList();

            return Json(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            try
            {
                bool exists = _unitOfWork.User.ExistsBy(c => c.UserName.Equals(user.UserName));
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên  Usernam đã tồn tại"
                    });
                }
                else
                {
                    user.onCreate();
                    user.CreateBy = user.UserName;
                     // sau sua thanh bang thiet bi dang dang nhap
                    user.UpdateBy = user.UserName;
                    _unitOfWork.User.Add(user);
                    _unitOfWork.Save();
                }


                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _unitOfWork.User.Get(u => u.Id == id);
            if(user!= null)
            {
                return Ok(user);
            }
          
           return BadRequest("Username không tồn tại");
           
        }


        [HttpPost]
        public IActionResult Edit([FromBody] User user)
        {


            if (ModelState.IsValid)
            {
                // thêm dữ liệu vào database``
                user.onUpdate();

                // sau sửa thành người dùng đang nhăp nhập
                user.UpdateBy = user.UserName;
                _unitOfWork.User.Update(user);

                // lưu dữ liệu khi thêm
                _unitOfWork.Save();
                //TempData["success"] = "Category update successfully";
                return Ok(user);
            }

            // return View();
            // Nếu dữ liệu không hợp lệ, quay lại modal chỉnh sửa
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int ? id)
        {
            var user = _unitOfWork.User.Get(u=>u.Id==id);
            if (user!= null)
            {
                _unitOfWork.User.Remove(user);
                _unitOfWork.Save();
                return Ok("Xóa thành công");
            }

           
            return BadRequest("Xóa không hợp lệ");
        }


        public IActionResult CreateFakeUsers(int count)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.FullName, f => f.Name.FullName())
                .RuleFor(u => u.Gender, f => f.PickRandom("Male", "Female"))
                .RuleFor(u => u.Birthday, f => f.Date.Past())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.ApartmentNumber, f => f.Address.SecondaryAddress())
                .RuleFor(u => u.BankAccount, f => f.Finance.Account())
                .RuleFor(u => u.Status, f => f.Random.Number(0, 1))
                .RuleFor(u => u.RestaurantId, f => f.Random.Number(5, 29))
                .RuleFor(u => u.Role, f => "User"); // Ví dụ, bạn có thể đặt vai trò mặc định ở đây

            var users = faker.Generate(count);


            foreach (var user in users)
            {
                _unitOfWork.User.Add(user);
            }
            _unitOfWork.Save();

            return Json("Tạo thành công");
        }

        public IActionResult CreateFakeRestaurants(int count)
        {
            var faker = new Faker<Restaurant>()
                .RuleFor(r => r.RestaurantName, f => f.Company.CompanyName())
                .RuleFor(r => r.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.OpenTime, f => f.Date.Soon())
                .RuleFor(r => r.CloseTime, f => f.Date.Soon(1, DateTime.Now.AddHours(1))); // CloseTime sau một giờ kể từ OpenTime

            var restaurants = faker.Generate(count);

            foreach (var restaurant in restaurants)
            {
                _unitOfWork.Restaurant.Add(restaurant);
            }

            _unitOfWork.Save();

            return Json("Tạo thành công");
        }

    }
}
