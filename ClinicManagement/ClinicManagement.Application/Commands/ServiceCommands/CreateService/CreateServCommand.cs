using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ServiceCommands.CreateService
{
    public class CreateServCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreateServCommand(string name, string description, double value, int duration)
        {
            Name = name;
            Description = description;
            Value = value;
            Duration = duration;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Value { get; private set; }
        public int Duration { get; private set; }
    }
}
