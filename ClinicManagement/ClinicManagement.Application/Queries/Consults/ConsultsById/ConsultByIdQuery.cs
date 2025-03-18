using ClinicManagement.Application.Dtos.Consults;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.ConsultsById
{
    public class ConsultByIdQuery : IRequest<ResultViewModel<ResponseConsutById>>
    {
        public ConsultByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
