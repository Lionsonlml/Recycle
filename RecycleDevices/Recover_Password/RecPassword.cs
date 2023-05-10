
namespace Login.Recover_Password;

using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Descripción breve de contraseña
/// </summary>
public class RecPassword
{
    private string correo = "nico.rodriguez.torres.71@gmail.com";
    private string contrasena = "eqegrqjrjhfylryr";
    
    public RecPassword()
    {
        
    }
    //public Token validartoken(string token, int id)
    //{
    //    return new LoginContext().Tokens.Where(x => x.tactivo == token && x.id_user == id).FirstOrDefault();
    //}

    //public string encriptar(string input)
    //{
    //    SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
    //    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    //    byte[] hashedBytes = provider.ComputeHash(inputBytes);
    //    StringBuilder output = new StringBuilder();

    //    for (int i = 0; i < hashedBytes.Length; i++)
    //    {
    //        output.Append(hashedBytes[i].ToString("x2").ToLower());
    //    }
    //    return output.ToString();
    //}

    public void enviarmail(string correodestino)
    {
        //mail
        string correol = "<body>"
+ "<table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0'>"
+ "<tr>"
+ "<td class='esd-block-banner' style='position: relative;' align='center' esdev-config='h1'><a target='_blank'><img class='adapt-img esdev-stretch-width esdev-banner-rendered' src='https://www.nicepng.com/png/full/414-4144393_en-virtud-de-su-misin-2015-se-busca.png'alt title style='display: block;' width='100%'></a>"
+ "</td>"
+ "</tr>"
+ "<tr>"
+ "<tr>"
+ "<td class='esd-block-text es-p15t es-p15b es-p20r es-p20l' bgcolor='transparent' align='center'>"
+ "<h2 style='color: #333333;'>" + "Señor Usuario \n</h2>"
+ "</td>"
+ "</tr>"
+ "<tr>"
+ "<td class='esd-block-text es-p15b es-p30r es-p30l' bgcolor='transparent' align='center'>"
+ "<h3 style='line-height: 150%;'><em>Usted a solicitado un recuperacion de contraseña, utilice este codigo para recuperar su contraseña ahoramismo.\n" +
        "Cuenta con diez (10) minutos para hacer valida la recuperacion.\n" + "su codigo de acceso es \n" + " <a href='http://localhost:7156/loggins/PassworRec.cshtml?tk='>" + "RECUPERAR" + "</a></em></h3>"
+ "</td>"
+ "</tr>"
+ "</tr>"
+ "<tr>"
+ "<tr>"
+ "<td class='esd-block-image' align='center' style='font-size:0'><a target='_blank'><img class='adapt-img' src='IMAGEN' alt style='display: block;' width='600'></a>"
+ "</td>"
+ "</tr>"
+ "</tr>"
+ "</table>"
+ "</body>";
        MailMessage mail = new MailMessage();
        SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");
        mail.IsBodyHtml = true;
        mail.From = new MailAddress(correo, "Recuperacion contrasena");//correo que envia, diplay name
        SmtpSever.Host = "smtp.gmail.com";//servidor gmail
        mail.Subject = "Recupere su contraseña";//asunto
        mail.Body = correol;
        mail.To.Add(correodestino);//destino del correo
        mail.Priority = MailPriority.Normal;

        //Configuracion del SMTP
        SmtpSever.Port = 587;
        SmtpSever.Credentials = new System.Net.NetworkCredential(correo, contrasena);//correo origen, contra*
        SmtpSever.EnableSsl = true;
        SmtpSever.Send(mail);//eviar
                             //mail

    }
}