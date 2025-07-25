using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.ResetPassword
{
    public class ValidateCodePassword
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
