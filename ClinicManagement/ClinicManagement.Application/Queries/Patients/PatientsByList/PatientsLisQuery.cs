using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Dtos.Patients;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Patients.PatientsByList
{
    public class PatientsLisQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<ResponsePatientsAll>>>
    {
        public PatientsLisQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
