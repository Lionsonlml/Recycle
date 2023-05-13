using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleDevices.Models
{
    public class Domiciliario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { set; get; }
        public long  cc { set; get; }
        public string? Name { set; get; }
        public string? LastName { set; get; }
        public string? Email { set; get; }
        public string? password { set; get; }
        public int roll { set; get; }
    }
}
