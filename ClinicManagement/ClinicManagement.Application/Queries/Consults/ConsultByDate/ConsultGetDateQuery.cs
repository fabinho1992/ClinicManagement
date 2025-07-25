using ClinicManagement.Application.Dtos.Consults;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.ConsultByDate
{
    public class ConsultGetDateQuery : IRequest<ResultViewModel<List<ResponseConsultsAll>>>
    {
        public ConsultGetDateQuery(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; private set; }
    }
}
