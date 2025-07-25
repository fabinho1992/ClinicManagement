using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.PatientCommands.DeleteCommand
{
    public class DeletePatientCommand : IRequest<ResultViewModel<Guid>>
    {
        public DeletePatientCommand(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; private set; }
    }
}
