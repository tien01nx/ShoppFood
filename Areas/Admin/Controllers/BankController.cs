using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers
{
    public class BankController : BaseController<Bank>
    {

        private readonly IUnitOfWork _unitOfWork;

        public BankController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var banks = _unitOfWork.Bank.Get(u => u.UserId == userId);
            if(banks!= null)
            {
                return Ok(banks);
            }
          
            return BadRequest("Username không tồn tại");
           
        }
        
        [HttpDelete]
        public IActionResult Delete(int ? id)
        {
            var bank = _unitOfWork.Bank.Get(u=>u.Id==id);
            if (bank!= null)
            {
                _unitOfWork.Bank.Remove(bank);
                _unitOfWork.Save();
                return Ok("Xóa thành công");
            }

           
            return BadRequest("Xóa không hợp lệ");
        }
        
        [HttpPost]
        public IActionResult AddOrUpdateBank(int userId,[FromBody] Bank bank)
        {
            var user = _unitOfWork.User.Get(u => u.Id == userId, includeProperties: "Banks");
            bank.UserId = userId;
            if (user != null)
            {
            
                var existingBank = user.Banks.FirstOrDefault(b => b.BankName == bank.BankName);

                if (existingBank != null)
                {
                   
                    existingBank.BankName = bank.BankName;
                    existingBank.ImageUrl = bank.ImageUrl;
                    _unitOfWork.Bank.Update(existingBank);
              
                }
                else
                {
             
                  _unitOfWork.Bank.Add(bank);
                }

             
                _unitOfWork.Save();

                return Ok("Đã thêm hoặc cập nhật ngân hàng thành công.");
            }

            return NotFound("Người dùng không tồn tại.");
        }

    
    }
}
