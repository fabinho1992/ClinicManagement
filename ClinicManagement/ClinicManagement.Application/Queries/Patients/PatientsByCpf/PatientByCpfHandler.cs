using ClinicManagement.Application.Dtos.Addresses;
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

namespace ClinicManagement.Application.Queries.Patients.PatientsByCpf
{
    public class PatientByCpfHandler : IRequestHandler<PatientByCpfQuery, ResultViewModel<ResponsePatientsDetails>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientByCpfHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<ResponsePatientsDetails>> Handle(PatientByCpfQuery request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByCpfAsync(request.Cpf);
            if (patient is null)
            {
                return ResultViewModel<ResponsePatientsDetails>.Error("The Patient could not be found");
            }

            var addreess = new ResponseAddress
            {
                Street = patient.Address.Street,
                City = patient.Address.City,
                State = patient.Address.State,
                Complement = patient.Address.Complement
            };

            var consults = new List<RespConsutPatient>();
            foreach (var consult in patient.Consults)
            {
                var newConsult = new RespConsutPatient
                {
                    NameDoctor = consult.Doctor.Name,
                    NameService = consult.Service.Name,
                    Convention = consult.Convention,
                    TypeTreatment = consult.TypeTreatment.ToString(),
                    DateConsult = consult.Start.ToString("d"),
                    Start = consult.Start.ToString("t"),
                    Finish = consult.Finish.ToString("t")
                };

                consults.Add(newConsult);
            }

            var patientResponse = new ResponsePatientsDetails(patient.Id, patient.Name, patient.DateOfBirth.ToString("d"),
                patient.BloodType, patient.Phone, patient.Email, patient.Cpf, addreess, consults);


            return ResultViewModel<ResponsePatientsDetails>.Success(patientResponse);
        }
    }
}
