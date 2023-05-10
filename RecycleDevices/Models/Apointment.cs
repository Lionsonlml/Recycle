namespace RecycleDevices.Models
{
    public class Apointment
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int DeliveryID { get; set; }
        public string Country { get; set; }
        public string Departament { get; set; }
        public string Municipality { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int PackageId { get; set; }
        public int ProductCategoryID { get; set;}
        public string State { get; set; }
        public int Points { get; set; }

    }
}
