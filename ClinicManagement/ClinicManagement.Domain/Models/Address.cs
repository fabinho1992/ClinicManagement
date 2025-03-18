using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string street, string city, string state, string zipCode,
            string complement, Guid? doctorId, Guid? patientId, TypeUser typeUser)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;
            DoctorId = doctorId;
            PatientId = patientId;
            TypeUser = typeUser;
            Id = Guid.NewGuid();
        }


        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; set; }
        public Guid? DoctorId { get; private set; }
        public Guid? PatientId { get; private set; }
        public TypeUser TypeUser { get; private set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }


        public void UpdateAddress(string street, string city, string state, string zipCode,
            string complement, Guid? doctorId, Guid? patientId, TypeUser typeUser)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;
            DoctorId= doctorId;
            PatientId = patientId;
            TypeUser = typeUser;
        }

    }
}
