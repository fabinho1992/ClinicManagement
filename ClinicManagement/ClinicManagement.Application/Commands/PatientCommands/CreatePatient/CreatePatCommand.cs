using ClinicManagement.Domain.Enuns;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.PatientCommands.CreatePatient
{
    public class CreatePatCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreatePatCommand(string name, DateTime dateOfBirth, BloodType bloodType, string phone, 
            string email, string cpf, string zipCode, string complement, double height, double weight)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            ZipCode = zipCode;
            Complement = complement;
            Height = height;
            Weight = weight;
        }

        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
    }
}
