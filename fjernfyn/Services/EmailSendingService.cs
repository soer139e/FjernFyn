using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Interfaces;

namespace fjernfyn.Services
{
    public class EmailSendingService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("johnisdoe906@gmail.com", "klib zrby arsb shii")
            };

            return client.SendMailAsync(new MailMessage(from: "johnisdoe906@gmail.com", to: email, subject, message));
        }
    }
}
