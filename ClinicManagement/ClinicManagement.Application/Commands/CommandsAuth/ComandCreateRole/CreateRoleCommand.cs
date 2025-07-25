using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsAuth.ComandCreateRole
{
    public class CreateRoleCommand : IRequest<ResultViewModel<string>>
    {
        public CreateRoleCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
