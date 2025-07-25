using ClinicManagement.Application.Dtos.Patients;
using ClinicManagement.Application.Dtos.Services;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Services.ServicesByList
{
    public class ServiceByListQueryHandler : IRequestHandler<ServiceByListQuery, ResultViewModel<List<ResponseServisesList>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceByListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<ResponseServisesList>>> Handle(ServiceByListQuery request, CancellationToken cancellationToken)
        {
            var (services, totalCount) = await _unitOfWork.ServiceRepository.GetAll(request);
            if(services is null)
            {
                return ResultViewModel<List<ResponseServisesList>>.Error("Services not found.");
            }

            var newServices = new List<ResponseServisesList>();
            foreach (var service in services)
            {
                var newService = new ResponseServisesList(service.Id, service.Name, service.Description, service.Value, service.Duration);
                newServices.Add(newService);
            }

            return ResultViewModel<List<ResponseServisesList>>.Success(newServices, totalCount);
        }
    }
}
