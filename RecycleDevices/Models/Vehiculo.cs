using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleDevices.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Placa { get; set; }
        public String IDDomiciliario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        
    }
}
