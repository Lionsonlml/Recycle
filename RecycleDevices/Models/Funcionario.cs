using System.ComponentModel.DataAnnotations;

namespace RecycleDevices.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { set;get;}
        public string Name { set;get;}
        public int TypeId { set;get;}
        public int roll { set; get; }
        public string LastName{ set;get;}
        public string email{ set;get;}
        public string password{ set;get;}
        public string NivelEstudio { set;get;}
        public string Cargo { set;get;}
    }
}
