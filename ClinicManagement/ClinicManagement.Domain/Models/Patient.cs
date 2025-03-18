using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Patient : Base
    {
        public Patient() : base(string.Empty, DateTime.MinValue, BloodType.A, string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public Patient(string name, DateTime dateOfBirth, BloodType bloodType,
            string phone, string email, string cpf, string zipCode, double height, double weight) : base(name, dateOfBirth, bloodType, phone, email, cpf, zipCode)
        {
            Height = height;
            Weight = weight;
        }

        public double Height { get; private set; }
        public double Weight { get; private set; }



        public void UpdatePatient(double height, double weight)
        {
            Height = height;
            Weight = weight;
        }
    }
}
