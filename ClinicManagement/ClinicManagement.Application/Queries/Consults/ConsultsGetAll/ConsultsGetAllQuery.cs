using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Dtos.Consults;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Consults.CnosultsGetAll
{
    public class ConsultsGetAllQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<ResponseConsultsAll>>>
    {
        public ConsultsGetAllQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
