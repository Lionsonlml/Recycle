namespace RecycleDevices.Models
{ 
    public class Package
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }       
        public string Description { get; set; }
    }
}
