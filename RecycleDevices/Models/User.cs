using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace RecycleDevices.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public int cc { get; set; }
        public string? email { get; set; }
        public int roll { get; set; }
        public float points { get; set; }
        public int phoneNumber { get; set; }

    }
}
