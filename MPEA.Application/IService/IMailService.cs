using MPEA.Application.BaseModel;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface IMailService
    {
        Task SendEmail(MailModel request);
        Task SendUserInformation(User account, string password);
        Task SendConfirmRegistration(User account);
    }
}
