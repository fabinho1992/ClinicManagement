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
    public class ConsultRepository : RepositoryBase<Consult>, IConsulRepository
    {
        private readonly ClinicDbContext _context;

        public ConsultRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Consult> GetByIdAsync(Guid id)
        {
            var treatment = await _context.Consults
                .Include(t => t.Patient)
                .Include(t => t.Doctor)
                .Include(t => t.Service)
                .SingleOrDefaultAsync(t => t.Id == id);

            return treatment;
        }

        public async Task<Consult> GetByIdPatient(Guid id)
        {
            var consult = await _context.Consults
                .Where(c => c.PatientId == id) 
                .OrderByDescending(c => c.CreatAt) 
                .FirstOrDefaultAsync(); 

            return consult;
        }
    }
}
