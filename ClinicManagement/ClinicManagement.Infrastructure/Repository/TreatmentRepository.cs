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
    public class TreatmentRepository : RepositoryBase<Treatment>, ITreatmentRepository
    {
        private readonly ClinicDbContext _context;

        public TreatmentRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Treatment> GetByIdAsync(Guid id)
        {
            var treatment = await _context.Treatments
                .Include(t => t.Patient)
                .Include(t => t.Doctor)
                .Include(t => t.Service)
                .SingleOrDefaultAsync(t => t.Id == id);

            return treatment;
        }
    }
}
