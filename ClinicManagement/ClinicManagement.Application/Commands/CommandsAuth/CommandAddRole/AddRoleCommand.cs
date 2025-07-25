using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsAuth.CommandAddRole
{
    public class AddRoleCommand : IRequest<ResultViewModel<string>>
    {
        public AddRoleCommand(string email, string nameRole)
        {
            Email = email;
            NameRole = nameRole;
        }

        public string Email { get; private set; }
        public string NameRole { get; private set; }
    }
}
