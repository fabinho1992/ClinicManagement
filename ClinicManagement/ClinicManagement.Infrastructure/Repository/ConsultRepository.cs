using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Infrastructure.Context;
using Infraestrutura.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClinicManagement.Infrastructure.Repository
{
    public class ConsultRepository : RepositoryBase<Consult>, IConsulRepository
    {
        private readonly ClinicDbContext _context;

        public ConsultRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Consult> GetByCertificate(DateTime date, string cpf)
        {
            var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            var consult = await _context.Consults
            .Include(c => c.Patient)
            .Include(c => c.Doctor)
            .Where(c => c.Start.Date == utcDate.Date && c.Patient.Cpf == cpf)
            .FirstOrDefaultAsync();

            return consult;
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

        public async Task<List<Consult>> GetEmailWarning()
        {
            return await _context.Consults
               .Include(x => x.Patient)
               .Include(x => x.Doctor)
               .Include(x => x.Service)
               .Where(x => x.Start <= DateTime.UtcNow.AddDays(1) && x.Start >= DateTime.UtcNow)
               .AsNoTracking()
               .ToListAsync();
        }



        public async Task<List<Consult>> GetAllAsync(ParametrosPaginacao parametrosPaginacao)
        {
            return await _context.Consults
                .Skip((parametrosPaginacao.PageNumber - 1) * parametrosPaginacao.PageSize)
                .Take(parametrosPaginacao.PageSize)
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .Include(c => c.Service)
                .OrderBy(c => c.CreatAt)
                .ToListAsync();
        }

        public async Task<List<Consult>> GetAllByDate(DateTime date)
        {
            var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            var consults = await _context.Consults
           .Include(c => c.Patient)
           .Include(c => c.Doctor)
           .Include(c => c.Service)
           .Where(c => c.Start.Date == utcDate.Date)
           .ToListAsync();

            return consults;

        }
    }
}
