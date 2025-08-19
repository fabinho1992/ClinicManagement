using ClinicManagement.Infrastructure.Context;
using ClinicManagement.Infrastructure.Context.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManagement.Infrastructure.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly DbContextOptions<DbContextIdentity> _options;

        public RepositoryUser(DbContextOptions<DbContextIdentity> options)
        {
            _options = options;
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            using (var context = new DbContextIdentity(_options))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }

        }

        public async Task<ApplicationUser> GetById(Guid id)
        {
            using (var context = new DbContextIdentity(_options))
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
            }

        }

        public async Task<bool> IsResetTokenValid(string email, string token)
        {
            using (var context = new DbContextIdentity(_options))
            {
                var utcDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    return user.ResetToken == token && user.ResetTokenExpiration > utcDate;
                }
                return false;
            }
        }

        public async Task StoreResetToken(string email, string token, DateTime expirationDate)
        {
            using (var context = new DbContextIdentity(_options))
            {
                // Aqui você pode armazenar o token e a data de expiração em uma tabela no banco de dados
                var utcDate = DateTime.SpecifyKind(expirationDate, DateTimeKind.Utc);
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    user.ResetToken = token; // Supondo que você tenha uma propriedade ResetToken na sua entidade
                    user.ResetTokenExpiration = utcDate; // E uma propriedade para a data de expiração
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
