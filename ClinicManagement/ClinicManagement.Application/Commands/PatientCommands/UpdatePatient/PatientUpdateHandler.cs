using BloodDonationDataBase.Domain.IServices;
using ClinicManagement.Domain.Enuns;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.PatientCommands.UpdatePatient
{
    public class PatientUpdateHandler : IRequestHandler<PatientUpdateCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;
        private readonly ILogger<PatientUpdateHandler> _logger;

        public PatientUpdateHandler(IUnitOfWork unitOfWork, ILogger<PatientUpdateHandler> logger, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<Guid>> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(request.Id);

            var address = await _unitOfWork.AddressRepository.GetByIdUser(request.Id);

            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);

            if (zipCode is null)
            {
                return ResultViewModel<Guid>.Error("ZipCode not found");
            }

            address.UpdateAddress(zipCode.Logradouro, zipCode.Localidade, zipCode.Uf, zipCode.Cep, request.Complement, doctorId: null, patient.Id, TypeUser.Patient);

            patient.UpdateBase(request.Name, request.DateOfBirth, request.BloodType, request.Phone,request.Email, request.Cpf, request.ZipCode, address);

            await _unitOfWork.PatientRepository.Update(patient);
            await _unitOfWork.Commit();
            await _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.Commit();

            _logger.LogInformation("Updade Sucess _-_-_-_-_-_");

            return ResultViewModel<Guid>.Success(patient.Id);
        }
    }
}
