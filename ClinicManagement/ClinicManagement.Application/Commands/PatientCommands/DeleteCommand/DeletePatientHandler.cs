using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.PatientCommands.DeleteCommand
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByCpfAsync(request.Cpf);
            if (patient is null)
            {
                return ResultViewModel<Guid>.Error("Patient not found.");
            }

            await _unitOfWork.PatientRepository.Delete(patient.Id);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(patient.Id);
        }
    }
}
