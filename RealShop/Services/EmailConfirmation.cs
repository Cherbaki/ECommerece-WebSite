using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace RealShop.Services
{
    public class EmailConfirmation : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailConfirmation(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            MailMessage message = new();
            message.From = new MailAddress(_config.GetValue<string>("Smtp:FromAddress"));
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");

            var smtpClient = new SmtpClient(_config.GetValue<string>("Smtp:Server"))
            {
                Port = _config.GetValue<int>("Smtp:Port"),
                Credentials = new NetworkCredential(_config.GetValue<string>("Smtp:FromAddress"), _config.GetValue<string>("Smtp:Password")),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
            await smtpClient.SendMailAsync(message);
        }
    }
}
