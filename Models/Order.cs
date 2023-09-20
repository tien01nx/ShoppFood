using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppFood.Models
{
    public class Order : BaseModel
    {

      
        public int Id { get; set; }

        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }


     
        public DateTime OrderDate { get; set; }
     

        public DateTime ShoopingDate { get; set; }


     
        public double OrderTotal { get; set; }

      

        public string? OrderStatus { get; set; }

   
        public string? PaymentStatus { get; set; }
    }
}
