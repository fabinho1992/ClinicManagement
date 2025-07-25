﻿using ClinicManagement.Domain.IRepository.Generic;
using ClinicManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository
{
    public interface IDoctorRepository : IGeneric<Doctor>
    {
        Task<Doctor> GetByIdAsync(Guid id);
        Task<Doctor> GetByEmail(string email);
    }
}
