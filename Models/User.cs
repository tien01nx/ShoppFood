using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoppFood.Models
{
    public class User : BaseModel
    {
 
        public int Id { get; set; }  

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }


        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Avatar { get; set; }

        
        public string? State { get; set; }


        public string? PhoneNumber { get; set; }

        public string Address { get; set; }


        public string? ApartmentNumber { get; set; }

        public string BankAccount { get; set; }


        public int Status { get; set; }

        [NotMapped] public string? Role { get; set; }



        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        [ValidateNever]
        public Restaurant Restaurant { get; set; }







    }
}
