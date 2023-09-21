using Microsoft.AspNetCore.Mvc;
using ShoppFood.DataAccess.Repository.IRepository;
using ShoppFood.Models;

namespace ShoppFood.Areas.Admin.Controllers;

public class OrderController : BaseController<Order>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpPost]
    public IActionResult Upsert([FromBody] Order order)
    {
        try
        {
            order.ShoopingDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu đơn hàng không hợp lệ."
                });
            }

            if (order.Id == 0)
            {
                _unitOfWork.Order.Add(order);
                _unitOfWork.Save();
                return Ok(new
                {
                    message = "Thêm đơn hàng thành công.",
                    order = order
                });
            }
            else
            {
                order.UpdateDate = DateTime.Now;
                _unitOfWork.Order.Update(order);
                _unitOfWork.Save();
                return Ok(new
                {
                    message = "Cập nhật đơn hàng thành công.",
                    order = order
                });
            }
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                message = e.GetBaseException().Message
            });
        }
    }



    [HttpGet]
    public IActionResult Edit(int id)
    {
           
        var order  = _unitOfWork.Order.Get(u=>u.Id == id); 

        if(order != null)
        {
            return Ok(order);
        }
        return BadRequest("Không có Hóa đơn cần tìm");

         
    }
        

    [HttpDelete]
    public IActionResult Delete(int id)
    {

        var order  = _unitOfWork.Order.Get(u=>u.Id==id);
        if(order != null)
        {
            _unitOfWork.Order.Remove(order);
            return Ok("Xoa thanh cong");
        }

        return BadRequest("Id tim khong co");
    }
}