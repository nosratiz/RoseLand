using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineShop.Common.Options;

namespace OnlineShop.Common.EmailService
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailSetting _emailSetting;

        public EmailServices(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = new EmailSetting
            {
                Host = emailSetting.Value.Host,
                UserName = emailSetting.Value.UserName,
                Password = emailSetting.Value.Password,
                Port = emailSetting.Value.Port,
                From = emailSetting.Value.From
            };
        }

        public async Task SendMessage(string emailTo, string subject, string body)
        {
            MailMessage message = new MailMessage(_emailSetting.From, emailTo, subject, body)
            {
                IsBodyHtml = true,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.Default
            };

            NetworkCredential credential = new NetworkCredential(_emailSetting.UserName, _emailSetting.Password);

            try
            {
                using SmtpClient smtp = new SmtpClient(_emailSetting.Host, _emailSetting.Port)
                {
                    Credentials = credential,
                    EnableSsl = true
                };


                await smtp.SendMailAsync(message).ConfigureAwait(false);


            }
            catch (Exception)
            {
                //
            }



        }
    }
}