﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.ModelsReport
{
    public class PatientCertificate
    {
        public DateTime Date { get; set; }
        public string Cpf { get; set; }
        public int Days { get; set; }
    }
}
