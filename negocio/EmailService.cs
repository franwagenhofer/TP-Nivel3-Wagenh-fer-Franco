using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;


        //Configuracion para Mailtrap
        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("17087853c2b0ef", "bcebca1b1ec87c");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        // Configuracion para Outlook/Hotmail
        //public EmailService(string email, string contraseña)
        //{
        //    server = new SmtpClient();
        //    server.Credentials = new NetworkCredential(email, contraseña);
        //    server.EnableSsl = true;
        //    server.Port = 587; // Puerto 587 para Outlook/Hotmail
        //    server.Host = "smtp.office365.com"; // Host para Outlook/Hotmail
        //}

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@catalogoweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
