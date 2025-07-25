using ClinicManagement.Application.Dtos.Consults;
using ClinicManagement.Application.Queries.Consults.CnosultsGetAll;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.ConsultsGetAll
{
    public class ConsultGetAllHandler : IRequestHandler<ConsultsGetAllQuery, ResultViewModel<List<ResponseConsultsAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultGetAllHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<ResponseConsultsAll>>> Handle(ConsultsGetAllQuery request, CancellationToken cancellationToken)
        {
            var consults= await _unitOfWork.ConsultRepository.GetAllAsync(request);
            if(consults is null)
            {
                return ResultViewModel<List<ResponseConsultsAll>>.Error("Consults not found.");
            }

            var totalCount = consults.Count;

            var responseConsults = new List<ResponseConsultsAll>();
            foreach(var consult in consults)
            {
                var newConsult = new ResponseConsultsAll(consult.Id, consult.Patient.Name, consult.Doctor.Name, consult.Service.Name, consult.Convention, consult.Start.ToString("d"));
                responseConsults.Add(newConsult);
            }

            return ResultViewModel<List<ResponseConsultsAll>>.Success(responseConsults, totalCount);
        }
    }
}
