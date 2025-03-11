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
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        private readonly ClinicDbContext _context;

        public DoctorRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Treatments)
                .Include(d => d.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            return doctor;
        }
    }
}
