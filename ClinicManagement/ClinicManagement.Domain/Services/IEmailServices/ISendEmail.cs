using ClinicManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Services.EmailServices
{
    public interface ISendEmail
    {
        Task SendEmailConfirmation(Guid id);
        Task SendEmailWarning(string email, string name, string data);
        Task ResetPassword(string email, string name, string code);
    }
}
