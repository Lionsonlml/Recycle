using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecycleDevices.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int CC { get; set; }
        public string Email { get; set; }
        public int Roll { get; set; }
        public float Points { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Apointment> Apointments { get; set; }
    }
}
