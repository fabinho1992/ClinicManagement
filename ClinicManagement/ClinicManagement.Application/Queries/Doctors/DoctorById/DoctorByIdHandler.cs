using ClinicManagement.Application.Dtos.Addresses;
using ClinicManagement.Application.Dtos.Consults;
using ClinicManagement.Application.Dtos.Doctors;
using ClinicManagement.Application.Dtos.Patients;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Doctors.DoctorById
{
    public class DoctorByIdHandler : IRequestHandler<DoctorByIdQuery, ResultViewModel<ResponseDoctorById>>
    {
        private IUnitOfWork _unitOfWork;

        public DoctorByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<ResponseDoctorById>> Handle(DoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(request.Id);
            if (doctor is null)
            {
                return ResultViewModel<ResponseDoctorById>.Error("The Doctor could not be found");
            }

            var addreess = new ResponseAddress
            {
                Street = doctor.Address.Street,
                City = doctor.Address.City,
                State = doctor.Address.State,
                Complement = doctor.Address.Complement
            };

            var consults = new List<RespConsultDoctor>();
            foreach (var consult in doctor.Consults)
            {
                var newConsult = new RespConsultDoctor
                {
                    NamePatient = consult.Patient.Name,
                    NameService = consult.Service.Name,
                    Convention = consult.Convention,
                    TypeTreatment = consult.TypeTreatment.ToString(),
                    DateConsult = consult.Start.ToString("d"),
                    Start = consult.Start.ToString("t"),
                    Finish = consult.Finish.ToString("t")
                };

                consults.Add(newConsult);
            }

            var doctorReponse = new ResponseDoctorById(doctor.Id, doctor.Name, doctor.DateOfBirth.ToString("d"),
                doctor.BloodType, doctor.Phone, doctor.Email, doctor.Cpf, doctor.CRM, doctor.Specialty, addreess, consults);


            return ResultViewModel<ResponseDoctorById>.Success(doctorReponse);
        }
    }
}
