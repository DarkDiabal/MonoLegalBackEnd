using Microsoft.Extensions.Configuration;
using MonoLegal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MonoLegal.Business.Helpers
{
    public class NotificationHelper : INotificationHelper
    {
        private readonly IConfiguration _configuration;

        public NotificationHelper(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Method for send notification by Email
        /// </summary>
        /// <param name="template">Templete email</param>
        /// <param name="email">Recipient email</param>
        /// <returns></returns>
        public  async Task<bool> SendMail(TemplateEntity template, string email)
        {
            MailMessage msg = new MailMessage();            

            msg.To.Add(email);
            msg.From = new MailAddress(_configuration.GetSection("EmailOptions:MailSender").Value);
            msg.Subject = template.Subject;
            msg.SubjectEncoding = Encoding.UTF8;

            msg.BodyEncoding = Encoding.UTF8;
            msg.Body = template.Template;
            msg.IsBodyHtml = true;          

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(
                    _configuration.GetSection("EmailOptions:MailSender").Value, 
                    _configuration.GetSection("EmailOptions:EmailPassword").Value.ToString());

            client.Port = Convert.ToInt32(_configuration.GetSection("EmailOptions:SmtpPort").Value);
            client.EnableSsl = true;
            client.Host = _configuration.GetSection("EmailOptions:EmailHost").Value.ToString();

            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
