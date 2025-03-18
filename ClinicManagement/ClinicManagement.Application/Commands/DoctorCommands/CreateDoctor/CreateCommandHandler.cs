using BloodDonationDataBase.Domain.IServices;
using ClinicManagement.Domain.Enuns;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.DoctorCommands.CreateDoctor
{
    public class CreateCommandHandler : IRequestHandler<CreateDocCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateDocCommand request, CancellationToken cancellationToken)
        {
            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);

            if (zipCode is null)
            {
                return ResultViewModel<Guid>.Error("ZipCode not found");
            }

            var doctor = new Doctor(request.Name, request.DateOfBirth, request.BloodType,
                request.Phone, request.Email, request.Cpf, request.ZipCode, request.CRM, request.Specialty);
            await _unitOfWork.DoctorRepository.Add(doctor);
            await _unitOfWork.Commit();

            var address = new Address(street: zipCode.Logradouro, city: zipCode.Localidade, state: zipCode.Uf,
                zipCode: zipCode.Cep, complement: request.Complement, doctorId: doctor.Id, patientId: null, typeUser: TypeUser.Doctor);

            await _unitOfWork.AddressRepository.CreateAsync(address);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(doctor.Id);
        }
    }
}
