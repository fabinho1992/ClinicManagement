﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models.CepResponse
{
    public class ViaCepResponse
    {
        public string? Logradouro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
    }
}
