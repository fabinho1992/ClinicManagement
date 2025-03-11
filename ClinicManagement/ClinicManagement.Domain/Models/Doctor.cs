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
       

        public Doctor(string name, string surName, DateTime dateOfBirth, BloodType bloodType, 
            string phone, string email, string cpf, string crm, Specialty specialty) : base(name, dateOfBirth, bloodType, phone, email, cpf)
        {
            CRM = crm;
            Specialty = specialty;
        }

        public string CRM { get; private set; }
        public Specialty Specialty { get; private set; }
    }
}
