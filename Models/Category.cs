using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShoppFood.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Loại món ăn")]
        [MaxLength(30, ErrorMessage = "Giới hạn kí tự là 30")]
        public string ? Name { get; set; }


    }
}
