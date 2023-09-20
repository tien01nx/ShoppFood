using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppFood.Models
{
    public class Product : BaseModel
    {
        [Key] public int Id { get; set; }
        [Display(Name = "Title")]

        [Required] public string Title { get; set; }


        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Quantity")]
        [Range(1, 1000)]
        public int Quantity { get; set; }

    

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000000)]
        public double Price { get; set; }

    

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }


        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }


        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        [ValidateNever]
        public Restaurant Restaurant { get; set; }


    }
}
