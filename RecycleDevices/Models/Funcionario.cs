using System.ComponentModel.DataAnnotations;

namespace RecycleDevices.Models
{
    public class Funcionario
    {
        [Key]
        public String IdFun { set;get;}
        public String Name { set;get;}
        public String TypeId { set;get;}
        public String LastName{ set;get;}
        public String email{ set;get;}
        public String password{ set;get;}
        public String NivelEstudio { set;get;}
        public String Cargo { set;get;}
    }
}
