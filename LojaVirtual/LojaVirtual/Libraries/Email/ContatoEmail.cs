using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            /*
             * SMTP -> Servidor de envio da mensagem.
             */

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("benjaminperes@gmail.com", "");
            smtp.EnableSsl = true;

            string corpoMsg = String.Format("<h2>Contato - LojaVirtual</h2>" +
                "<b>Nome: </b> {0} <br />" +
                "<b>E-Mail</b> {1} <br />" +
                "<b>E-Mail</b> {2} <br />" + 
                "<br /> E-Mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            /*
             * MailMessage -> Construir a mensagem.
             */

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("benjaminperes@gmail.com");
            mensagem.To.Add(new MailAddress("benjaminperes@gmail.com"));
            mensagem.Subject = "Contato - LojaVirtual - E-Mail: "+ contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar Mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}
