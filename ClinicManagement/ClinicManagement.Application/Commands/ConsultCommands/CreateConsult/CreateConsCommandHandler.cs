using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.Services.EmailServices;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ConsultCommands.CreateConsult
{
    public class CreateConsCommandHandler : IRequestHandler<CreateConsCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendEmail _sendEmail;

        public CreateConsCommandHandler(IUnitOfWork unitOfWork, ISendEmail sendEmail)
        {
            _unitOfWork = unitOfWork;
            _sendEmail = sendEmail;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateConsCommand request, CancellationToken cancellationToken)
        {
            Consult consult = new Consult(request.PatientId, request.DoctorId, request.ServiceId,
                request.Convention, request.Start, request.Finish, request.TypeTreatment);

            await _unitOfWork.ConsultRepository.Add(consult);
            await _unitOfWork.Commit();

            await _sendEmail.SendEmailConfirmation(request.PatientId);

            return ResultViewModel<Guid>.Success(consult.Id);
        }
    }
}
