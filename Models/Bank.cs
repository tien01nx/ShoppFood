using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppFood.Models
{
    public class Bank :BaseModel
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string ImageUrl { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
