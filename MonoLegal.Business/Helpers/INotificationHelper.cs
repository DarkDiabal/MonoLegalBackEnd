using MonoLegal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonoLegal.Business.Helpers
{
    public interface INotificationHelper
    {
        /// <summary>
        /// Method for send notification by Email
        /// </summary>
        /// <param name="template">Templete email</param>
        /// <param name="email">Recipient email</param>
        /// <returns></returns>
        public Task<bool> SendMail(TemplateEntity template, string email);
    }
}
