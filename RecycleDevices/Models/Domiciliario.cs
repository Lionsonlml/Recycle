using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleDevices.Models
{
    public class Domiciliario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { set; get; }
        public string? IdDom { set; get; }
        public string? TypeId { set; get; }
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public string? Email { set; get; }
        public string? password { set; get; }
        public string? Day { set; get; }
        public DateTime HourInitial { set; get; }
        public DateTime HourEnd { set; get; }
        public int roll { set; get; }
    }
}
