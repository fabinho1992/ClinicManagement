using ClinicManagement.Domain.IRepository.Generic;
using ClinicManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository
{
    public interface IPatientRepository : IGeneric<Patient>
    {
        Task<Patient> GetByIdAsync(Guid id);
        Task<Patient> GetByCpfAsync(string cpf);
    }
}
