
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleDevices.Models
{
    public class Token

    { 
        [Key]
       // [Table("token", Schema = "dbo")]
        public int id_token { get; set; }

        [ForeignKey("USUARIO")]

        public int id_user { get; set; }

        public DateTime finicio { get; set; }

        public DateTime ffin { get; set; }
        public string? code { get; set; }
     
        public User USUARIO { get; set; }

    }






}

