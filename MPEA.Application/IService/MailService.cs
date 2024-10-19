using MPEA.Application.BaseModel;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MPEA.Application.IService
{
    public class MailService : IMailService
    {

        private readonly IConfiguration _configuration;
        private readonly string _templateDirectory;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _templateDirectory = Path.Combine(AppContext.BaseDirectory, configuration["EmailTemplateDirectory"]);
        }

        public Task SendUserInformation(User account, string password)
        {
            throw new NotImplementedException();
        }

        public async Task SendConfirmRegistration(User user)
        {
            var template = GetEmailTemplate("NotificationAccount.html");

            template = template.Replace("[Full Name]", user.FullName);

            var body = template;

            var mail = new MailModel();
            mail.To = user.Email;
            mail.Subject = "Account Registration Confirmation";
            mail.Body = body;
            await SendEmail(mail);
        }

        public async Task SendEmail(MailModel request)
        {
            var emailHost = _configuration["Email:EmailHost"];
            var emailUsername = _configuration["Email:EmailUsername"];
            var emailPassword = _configuration["Email:EmailPassword"];

            var fromAddress = new MailAddress(emailUsername);
            var toAddress = new MailAddress(request.To);

            var smtpClient = new SmtpClient(emailHost, 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailUsername, emailPassword),
                EnableSsl = true
            };

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true
            };

            await smtpClient.SendMailAsync(message);
        }

        public string GetEmailTemplate(string templateName)
        {
            var templatePath = Path.Combine(_templateDirectory, templateName);
            return File.ReadAllText(templatePath);
        }
    }
}
