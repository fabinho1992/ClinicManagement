using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.Services.EmailServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicManagement.Application.Services.EmailServices
{
    public class SendEmail : ISendEmail
    {
        IEmailService _emailService;
        IUnitOfWork _unitOfWork;
        ILogger<Consult> _logger;

        public SendEmail(IEmailService emailService, IUnitOfWork unitOfWork, ILogger<Consult> logger)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task ResetPassword(string email, string name, string code)
        {
            var message = $"Seu código para redefinição de senha é {code}";
            await _emailService.SendEmailService("Redefinição de Senha", message, email, name);
        }

        public async Task SendEmailConfirmation(Guid id)
        {
            var user = await _unitOfWork.PatientRepository.GetByIdAsync(id);

            var consult = await _unitOfWork.ConsultRepository.GetByIdPatient(id);

            var message = $"Olá {user.Name}\n\n" +
                    $"Este e-mail é enviado automaticamente, apenas para confirmar o agendamento " +
                    $"da sua consulta no dia {consult.Start.ToString("d")}";
            await _emailService.SendEmailService("Confirmation of appointment scheduling", message, user.Email, user.Name);

            _logger.LogInformation(message);
        }

        public async Task SendEmailWarning(string email, string name, string data)
        {
            var message = $"Olá {name}!!\n\n" +
                  $"Este e-mail é enviado automaticamente, um lembrete de que sua consulta está agendada para amanhã dia {data}!\n\n" +
                  "Não se esqueça de trazer seus documentos.";

            await _emailService.SendEmailService("Lembrete consulta", message, email, name);

        }
    }
}
