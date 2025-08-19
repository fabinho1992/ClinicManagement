using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Context.User
{
    public interface IRepositoryUser
    {
        Task<ApplicationUser> GetById(Guid id);
        Task<ApplicationUser> GetByEmail(string email);
        Task StoreResetToken(string email, string token, DateTime expirationDate);
        Task<bool> IsResetTokenValid(string email, string token);
    }
}
