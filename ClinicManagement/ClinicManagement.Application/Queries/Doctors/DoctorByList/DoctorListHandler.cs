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

namespace ClinicManagement.Application.Queries.Doctors.DoctorByList
{
    public class DoctorListHandler : IRequestHandler<DoctorListQuery, ResultViewModel<List<ResponseDoctorAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<ResponseDoctorAll>>> Handle(DoctorListQuery request, CancellationToken cancellationToken)
        {
            var (doctors, totalCount) = await _unitOfWork.DoctorRepository.GetAll(request);

            if (doctors is null)
            {
                return ResultViewModel<List<ResponseDoctorAll>>.Error("The Doctors could not be found");
            }

            var listDoctors = new List<ResponseDoctorAll>();
            foreach (var doctor in doctors)
            {
                var responseDoctor = new ResponseDoctorAll(doctor.Id, doctor.Name, doctor.DateOfBirth.ToString("d"),
                    doctor.BloodType, doctor.Phone, doctor.Email, doctor.Cpf, doctor.CRM, doctor.Specialty);
                listDoctors.Add(responseDoctor);
            }

            Console.WriteLine(listDoctors);

            return ResultViewModel<List<ResponseDoctorAll>>.Success(listDoctors, totalCount);
        }
    }
}
