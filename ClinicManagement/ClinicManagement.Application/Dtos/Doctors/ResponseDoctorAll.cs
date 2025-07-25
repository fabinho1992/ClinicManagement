using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Doctors
{
    public class ResponseDoctorAll
    {
        public ResponseDoctorAll(Guid id, string name, string dateOfBirth, BloodType bloodType, string phone, 
            string email, string cpf, string cRM, Specialty specialty)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            CRM = cRM;
            Specialty = specialty;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string CRM { get; private set; }
        public Specialty Specialty { get; private set; }
    }
}
