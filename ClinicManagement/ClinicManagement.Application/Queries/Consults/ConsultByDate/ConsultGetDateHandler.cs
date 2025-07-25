using ClinicManagement.Application.Dtos.Consults;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.ConsultByDate
{
    public class ConsultGetDateHandler : IRequestHandler<ConsultGetDateQuery, ResultViewModel<List<ResponseConsultsAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultGetDateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<ResponseConsultsAll>>> Handle(ConsultGetDateQuery request, CancellationToken cancellationToken)
        {
            var consults = await _unitOfWork.ConsultRepository.GetAllByDate(request.Date);

            if (consults is null)
            {
                return ResultViewModel<List<ResponseConsultsAll>>.Error("Consults not found.");
            }

            var totalCount = consults.Count;

            var responseConsults = new List<ResponseConsultsAll>();
            foreach (var consult in consults)
            {
                var newConsult = new ResponseConsultsAll(consult.Id, consult.Patient.Name, consult.Doctor.Name, consult.Service.Name, consult.Convention, consult.Start.ToString("d"));
                responseConsults.Add(newConsult);
            }

            return ResultViewModel<List<ResponseConsultsAll>>.Success(responseConsults, totalCount);
        }
    }
}
