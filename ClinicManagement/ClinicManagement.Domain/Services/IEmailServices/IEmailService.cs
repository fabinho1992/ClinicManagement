using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Services.EmailServices
{
    public interface IEmailService
    {
        Task SendEmailService(string subject, string message, string userEmail, string userName);
    }
}
