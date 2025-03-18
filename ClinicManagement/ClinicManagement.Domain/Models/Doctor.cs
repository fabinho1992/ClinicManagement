using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Doctor : Base
    {

        public Doctor() : base(string.Empty, DateTime.MinValue, BloodType.A, string.Empty, string.Empty, string.Empty, string.Empty)
        {
            
        }


        public Doctor(string name, DateTime dateOfBirth, BloodType bloodType, 
            string phone, string email, string cpf, string zipCode, string crm, Specialty specialty) : base(name, dateOfBirth, bloodType, phone, email, cpf, zipCode)
        {
            CRM = crm;
            Specialty = specialty;
        }

        public string CRM { get; private set; }
        public Specialty Specialty { get; private set; }


        public void UpdateDoctor(string crm, Specialty specialty)
        {
            CRM = crm;
            Specialty = specialty;
        }

    }
}
