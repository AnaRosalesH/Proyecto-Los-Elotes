using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Utilidades
{
    public class Correo
    {

        public static void enviarCorreo(string correo, string mensajeCorreo)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("TiendaLosElotes@mail.com"));
            email.To.Add(MailboxAddress.Parse(correo));
            email.Subject = "¡Gracias por su compra!";
            email.Body = new TextPart(TextFormat.Plain) { Text = mensajeCorreo };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("viajerosender@gmail.com", "jeaynxqmcsxunyih");
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}
