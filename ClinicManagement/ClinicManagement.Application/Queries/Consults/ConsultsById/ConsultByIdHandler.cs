using ClinicManagement.Application.Dtos.Consults;
using ClinicManagement.Application.Dtos.Patients;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.ConsultsById
{
    public class ConsultByIdHandler : IRequestHandler<ConsultByIdQuery, ResultViewModel<ResponseConsutById>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<ResultViewModel<ResponseConsutById>> IRequestHandler<ConsultByIdQuery, ResultViewModel<ResponseConsutById>>.Handle(ConsultByIdQuery request, CancellationToken cancellationToken)
        {
            var consult = await _unitOfWork.ConsultRepository.GetByIdAsync(request.Id);
            if(consult is null)
            {
                return ResultViewModel<ResponseConsutById>.Error("The Consult could not be found");
            }

            var responseConsult = new ResponseConsutById(consult.Id, consult.Patient.Name, consult.Doctor.Name,
                consult.Service.Name, consult.Convention, consult.Start.ToString("d"), consult.CreatAt.ToString("d"),
                consult.Start.ToString("t"), consult.Finish.ToString("t"), consult.TypeTreatment.ToString());

            return ResultViewModel<ResponseConsutById>.Success(responseConsult);

        }
    }
}
