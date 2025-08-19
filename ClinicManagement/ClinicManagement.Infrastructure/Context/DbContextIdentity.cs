using ClinicManagement.Infrastructure.Context.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Context
{
    public class DbContextIdentity : IdentityDbContext<ApplicationUser>
    {
        public DbContextIdentity(DbContextOptions<DbContextIdentity> options) : base(options)
        {
        }
    }
}
