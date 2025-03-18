using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.ServicesEmail
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

        public async Task SendEmailConfirmation(Guid id)
        {
            var user = await _unitOfWork.PatientRepository.GetByIdAsync(id);
             
            var consult = await _unitOfWork.ConsultRepository.GetByIdPatient(id);

            var message = $"Hello {user.Name}<br/>" +
               $"This email is sent automatically, just to confirm the scheduling " +
               $"of your appointment on the day {consult.Start.ToString("d")}";

            await _emailService.SendEmailService("Confirmation of appointment scheduling", message, user.Email, user.Name);

            _logger.LogInformation(message);
        }
    }
}
