using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDDomiciliarioVehiculo.Models
{
    public class Domiciliario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }
        public string IdDom { set; get; }
        public string TypeId { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public String Email { set; get; }
        public String password { set; get; }
        public String Day { set; get; }
        public DateTime HourInitial { set; get; }
        public DateTime HourEnd { set; get; }
        public String Rol { set; get; }
    }
}
