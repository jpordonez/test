using Framework.Constantes;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Framework.Util
{
    public class Mail
    {
        public static void enviar(List<string> receptores, string html, string asunto)
        {
            if (!receptores.Any())
            {
                throw new System.Exception("No se puede enviar el mail no se encontraron receptores.");
            }
            var cuenta = AppSettings.Get<string>(ConstantesWebConfig.MAIL_CUENTA);
            var clave = AppSettings.Get<string>(ConstantesWebConfig.MAIL_CLAVE);
            var servidor = AppSettings.Get<string>(ConstantesWebConfig.MAIL_SERVIDOR);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(cuenta);

            foreach (var receptor in receptores)
            {
                msg.To.Add(receptor);
            }

            msg.Subject = asunto;
            msg.Body = html;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = servidor;
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(cuenta, clave);
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                msg.Dispose();
            }
        }

    }
}
