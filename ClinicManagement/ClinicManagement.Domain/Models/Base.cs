﻿using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Base
    {
        public Base(string name, DateTime dateOfBirth, BloodType bloodType,
            string phone, string email, string cpf)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            Phone = phone;
            Email = email;
            Cpf = cpf;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public Address? Address { get; set; }
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();

    }
}
