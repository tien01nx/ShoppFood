using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace ShoppFood.Models
{
    public class Restaurant : BaseModel
    {

        public int Id { get; set; }
        public string RestaurantName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }

     


    }
}
