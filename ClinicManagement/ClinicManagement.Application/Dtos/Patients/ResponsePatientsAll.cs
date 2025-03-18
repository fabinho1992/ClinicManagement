using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Patients
{
    public class ResponsePatientsAll
    {
        public ResponsePatientsAll(Guid id, string name, string dateOfBirth, BloodType bloodType,
            string phone, string email, string cpf)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
