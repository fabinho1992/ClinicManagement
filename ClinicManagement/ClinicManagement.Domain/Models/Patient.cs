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
        public Patient(string name, string surName, DateTime dateOfBirth, BloodType bloodType,
            string phone, string email, string cpf, double height, double weight) : base(name, dateOfBirth, bloodType, phone, email, cpf)
        {
            Height = height;
            Weight = weight;
        }

        public double Height { get; private set; }
        public double Weight { get; private set; }
    }
}
