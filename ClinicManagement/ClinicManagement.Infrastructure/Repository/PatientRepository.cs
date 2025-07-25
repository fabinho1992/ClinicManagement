using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Infrastructure.Context;
using Infraestrutura.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        private readonly ClinicDbContext _context;

        public PatientRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Patient> GetByCpfAsync(string cpf)
        {
            var patient = await _context.Patients
               .Include(p => p.Consults)
                   .ThenInclude(c => c.Doctor)
               .Include(p => p.Consults)
                   .ThenInclude(c => c.Service)
               .Include(p => p.Address)
               .FirstOrDefaultAsync(p => p.Cpf == cpf);

            return patient;
        }

        public async Task<Patient> GetByEmail(string email)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == email);

            return patient;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var patient = await _context.Patients
                .Include(p => p.Consults)
                    .ThenInclude(c => c.Doctor) 
                .Include(p => p.Consults)
                    .ThenInclude(c => c.Service) 
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            return patient;
        }
    }
}
