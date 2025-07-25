using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ServiceCommands.DeleteService
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Id);
            if(service is null)
            {
                return ResultViewModel<Guid>.Error("Service not found.");
            }

            await _unitOfWork.ServiceRepository.Delete(service.Id);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(service.Id);


        }
    }
}
