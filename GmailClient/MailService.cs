using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace GmailClient
{
    public class MailService
    {
        private SmtpClient smtp;
        static string smtpAddress = "smtp.gmail.com";
        private string emailAddress;

        public MailService(string emailAddress, string password)
        {
            this.smtp = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = smtpAddress,
                EnableSsl = true,
                Credentials = new NetworkCredential(emailAddress, password)
            };
            this.emailAddress = emailAddress;

        }

        public void send(string emailToAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(emailAddress),
                Subject = subject,
                Body = body
            };
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(emailToAddress));
            smtp.Send(mail);

        }
    }
}
