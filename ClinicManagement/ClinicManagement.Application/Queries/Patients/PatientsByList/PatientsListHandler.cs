using ClinicManagement.Application.Dtos.Patients;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Patients.PatientsByList
{
    public class PatientsListHandler : IRequestHandler<PatientsLisQuery, ResultViewModel<List<ResponsePatientsAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientsListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<ResponsePatientsAll>>> Handle(PatientsLisQuery request, CancellationToken cancellationToken)
        {
            var patients = await _unitOfWork.PatientRepository.GetAll(request);
            if(patients is null)
            {
                return ResultViewModel<List<ResponsePatientsAll>>.Error("The Patients could not be found");
            }

            var listPatients = new List<ResponsePatientsAll>();
            foreach(var patient in patients)
            {
                var responsePatient = new ResponsePatientsAll(patient.Id, patient.Name, patient.DateOfBirth.ToString("d"),
                    patient.BloodType, patient.Phone, patient.Email, patient.Cpf);
                listPatients.Add(responsePatient);
            }

            return ResultViewModel<List<ResponsePatientsAll>>.Success(listPatients);
        }
    }
}
