
using System.Net.Mail;
namespace SGPTmvvm.Soporte
{
    public class EnviameElEmailCamaleon
    {
        public EnviameElEmailCamaleon(){}

        public bool EnviarEmail(string correoDirigidoA, string correoHostEmisor, string RazonSocial, string contrasena, string titulo, string cuerpo, int puerto, string host, bool sslOk)
        {

            
            //string emisorAb =  "holahola@saludosdeeliezer.com";

            MailMessage msg = new MailMessage(); //(emisorAb, correoDirigidoA);

            msg.To.Add(correoDirigidoA);

            msg.From = new MailAddress(correoHostEmisor, RazonSocial, System.Text.Encoding.UTF8);

            //msg.To.Add("elidimas10@gmail.com");

            //msg.From = new MailAddress("uno@uno.com", "trucutucu", System.Text.Encoding.UTF8);
            /************************************************/
            //string to = "elidimas10@gmail.com";
            //string from = "elidimas10@gmail.com";
            //MailMessage message = new MailMessage(from, to);
            //message.Subject = "Sistema Gestor Papeles Trabajo.";
            //message.Body = @"prueba de confirmacion de mensajito .";
            //SmtpClient client = new SmtpClient(server);

            //client.UseDefaultCredentials = true;
            /***************************************************/

            //msg.Subject = "Saludos de Eliel";
            msg.Subject = @titulo;

            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            //msg.Body = "Prueba envio sms";
            msg.Body = cuerpo;

            msg.BodyEncoding = System.Text.Encoding.UTF8;

            msg.IsBodyHtml = false; //Si vas a enviar un correo con contenido html entonces cambia el valor a true

            //Aquí es donde se hace lo especial
            //ImapClient a = new ImapClient();

            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(correoHostEmisor, contrasena);

            //client.Port = 587;
            client.Port = puerto;

            //client.Host = "smtp.gmail.com";//Este es el smtp valido para Gmail
            client.Host = host;

            //client.Port=25 o el 465 para hotmail 
            //client.Host = "smtp.live.com"; //Este es el smtp valido para Hotmail

            //client.Port=25 o el 465 para yahoo 
            //client.Host = "smtp.mail.yahoo.com"; //Este es el smtp para Yahoo

            //client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            client.EnableSsl = sslOk;

            try
            {
                client.Send(msg);
                msg.Dispose();
                return true;
            }

            catch (System.Exception)
            {
                return false;
            }

        }
    }
}
