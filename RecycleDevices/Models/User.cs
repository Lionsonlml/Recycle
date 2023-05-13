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
        public long cc { get; set; }
        public string? email { get; set; }
        public int roll { get; set; }
        public float points { get; set; }
        public long phoneNumber { get; set; }
        public string? password { get; set; }
       
        
        public string Encriptar(string clave)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(clave);
            result = Convert.ToBase64String(encryted);
            Console.WriteLine("clave encriptada" + result);
            return result;
        }
        public string DesEncriptar(string claveE)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(claveE);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                Console.WriteLine("clave desencriptada" + result);
                return result;
            }
            catch (Exception ex)
            {
                return claveE;
            }



        }
    }

}
