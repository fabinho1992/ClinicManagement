using BloodDonationDataBase.Domain.Models;
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
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private readonly ClinicDbContext _context;

        public ServiceRepository(ClinicDbContext contextBase, ClinicDbContext context) : base(contextBase)
        {
            _context = context;
        }

        public async Task<Service> GetByIdAsync(Guid id)
        {
            var service = await _context.Services
                .Include(s => s.Consults)
                .SingleOrDefaultAsync(s => s.Id == id);

            return service;
        }
    }
}
