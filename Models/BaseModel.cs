namespace ShoppFood.Models
{
    public class BaseModel 
    {

        public string ?CreateBy { get; set; }

        public string ?UpdateBy { get; set; }

        public DateTime CreateDate { get; set; }


        public DateTime ?UpdateDate { get; set; }


        public void onCreate()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public void onUpdate()
        {
            UpdateDate = DateTime.Now;
        }


    }
}
