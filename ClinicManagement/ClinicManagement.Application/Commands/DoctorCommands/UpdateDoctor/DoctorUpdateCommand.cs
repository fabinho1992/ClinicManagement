using ClinicManagement.Domain.Enuns;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.DoctorCommands.UpdateDoctor
{
    public class DoctorUpdateCommand : IRequest<ResultViewModel<Guid>>
    {
        public DoctorUpdateCommand(Guid id, string name, DateTime dateOfBirth, BloodType bloodType, string phone, string email, string cpf, string zipCode, 
            string complement, string cRM, Specialty specialty)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            ZipCode = zipCode;
            Complement = complement;
            CRM = cRM;
            Specialty = specialty;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; set; }
        public string CRM { get; private set; }
        public Specialty Specialty { get; private set; }
    }
}
