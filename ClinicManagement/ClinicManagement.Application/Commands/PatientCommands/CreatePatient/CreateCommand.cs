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
    public class CreateCommand : IRequest<ResultViewModel<Guid>>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
    }
}
