using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ServiceCommands.CreateService
{
    public class CreateServCommandHandler : IRequestHandler<CreateServCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateServCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateServCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.Name, request.Description, request.Value, request.Duration);
            await _unitOfWork.ServiceRepository.Add(service);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(service.Id);

        }
    }
}
