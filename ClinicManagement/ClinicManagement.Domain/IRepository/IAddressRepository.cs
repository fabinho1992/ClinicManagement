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
        Task<Address> GetByIdAsync(Guid id);
    }
}
