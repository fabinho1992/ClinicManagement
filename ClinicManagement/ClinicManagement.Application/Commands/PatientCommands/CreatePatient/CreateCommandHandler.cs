using BloodDonationDataBase.Domain.IServices;
using ClinicManagement.Domain.Enuns;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.PatientCommands.CreatePatient
{
    public class CreateCommandHandler : IRequestHandler<CreatePatCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreatePatCommand request, CancellationToken cancellationToken)
        {
            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);

            if (zipCode is null)
            {
                return ResultViewModel<Guid>.Error("ZipCode not found");
            }

            var patient = new Patient(request.Name, request.DateOfBirth, request.BloodType,
                request.Phone, request.Email, request.Cpf, request.ZipCode, request.Height, request.Weight);
            await _unitOfWork.PatientRepository.Add(patient);
            await _unitOfWork.Commit();

            
            var address = new Address(street: zipCode.Logradouro, city: zipCode.Localidade, state: zipCode.Uf,
                zipCode: zipCode.Cep, complement: request.Complement,doctorId: null, patientId: patient.Id, typeUser: TypeUser.Patient);

            await _unitOfWork.AddressRepository.CreateAsync(address);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(patient.Id);

        }
        
            
    }
    
}
