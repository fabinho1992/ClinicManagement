using ClinicManagement.Application.Dtos.Addresses;
using ClinicManagement.Application.Dtos.Consults;
using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Patients
{
    public class ResponsePatientsDetails
    {
        public ResponsePatientsDetails(Guid id, string name, string dateOfBirth, BloodType bloodType, string phone,
            string email, string cpf, ResponseAddress responseAddress, List<RespConsutPatient>? respConsutPatients, double height, double weight)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
            ResponseAddress = responseAddress;
            RespConsutPatients = respConsutPatients;
            Height = height;
            Weight = weight;
        }

        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string DateOfBirth { get;  set; }
        public BloodType BloodType { get;  set; }
        public string Phone { get;  set; }
        public string Email { get;  set; }
        public string Cpf { get;  set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public ResponseAddress ResponseAddress { get; set; }
        public List<RespConsutPatient>? RespConsutPatients { get; set; }
    }
}
