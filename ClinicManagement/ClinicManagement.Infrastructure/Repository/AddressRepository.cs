using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using ClinicManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ClinicDbContext _context;

        public AddressRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            var address = await _context.Addresses
                .Include(a => a.TypeUser)
                .SingleOrDefaultAsync(a => a.Id == id);

            return address;
        }
    }
}
