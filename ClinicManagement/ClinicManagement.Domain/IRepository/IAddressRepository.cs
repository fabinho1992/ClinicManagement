using ClinicManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository
{
    public interface IAddressRepository
    {
        Task CreateAsync(Address address);
        Task<Address> GetByIdAsync(Guid id);
        Task Update(Address address);
        Task<Address> GetByIdUser(Guid id);
    }
}
