using BloodDonationDataBase.Domain.IServices;
using ClinicManagement.Domain.Enuns;
using ClinicManagement.Domain.IRepository;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.DoctorCommands.UpdateDoctor
{
    public class DoctorUpdateHandler : IRequestHandler<DoctorUpdateCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;
        public DoctorUpdateHandler(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<Guid>> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(request.Id);

            var address = await _unitOfWork.AddressRepository.GetByIdUser(request.Id);

            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);

            if (zipCode is null)
            {
                return ResultViewModel<Guid>.Error("ZipCode not found");
            }

            address.UpdateAddress(zipCode.Logradouro, zipCode.Localidade, zipCode.Uf, zipCode.Cep, request.Complement, doctor.Id, patientId: null, TypeUser.Doctor);

            doctor.UpdateBase(request.Name, request.DateOfBirth, request.BloodType, request.Phone, request.Email, request.Cpf, request.ZipCode, address);
            doctor.UpdateDoctor(request.CRM, request.Specialty);


            await _unitOfWork.DoctorRepository.Update(doctor);
            await _unitOfWork.Commit();
            await _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.Commit();


            return ResultViewModel<Guid>.Success(doctor.Id);
        }
    }
}
