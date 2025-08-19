using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Context.User
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string ResetToken { get; set; } = string.Empty;
        public DateTimeOffset ResetTokenExpiration { get; set; }
    }
}
