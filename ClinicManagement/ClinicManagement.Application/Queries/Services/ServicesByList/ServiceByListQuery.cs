using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Dtos.Services;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Services.ServicesByList
{
    public class ServiceByListQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<ResponseServisesList>>>
    {
        public ServiceByListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
