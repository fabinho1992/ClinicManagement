using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.DoctorCommands.DeleteCommand
{
    public class DeleteDoctorCommand : IRequest<ResultViewModel<Guid>>
    {
        public DeleteDoctorCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; } 
    }
}
