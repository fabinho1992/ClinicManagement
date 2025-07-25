using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.DoctorCommands.DeleteCommand
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(request.Id);
            if (doctor is null)
            {
                return ResultViewModel<Guid>.Error("Doctor not found.");
            }

            await _unitOfWork.DoctorRepository.Delete(doctor.Id);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(doctor.Id);
        }
    }
}
