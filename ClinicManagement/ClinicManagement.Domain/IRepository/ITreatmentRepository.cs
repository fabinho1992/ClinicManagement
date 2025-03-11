using ClinicManagement.Domain.IRepository.Generic;
using ClinicManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository
{
    public interface ITreatmentRepository : IGeneric<Treatment>
    {
        Task<Treatment> GetByIdAsync(Guid id);
    }
}
