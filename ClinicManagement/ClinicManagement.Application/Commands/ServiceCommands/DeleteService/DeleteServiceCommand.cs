using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ServiceCommands.DeleteService
{
    public class DeleteServiceCommand : IRequest<ResultViewModel<Guid>>
    {
        public DeleteServiceCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
