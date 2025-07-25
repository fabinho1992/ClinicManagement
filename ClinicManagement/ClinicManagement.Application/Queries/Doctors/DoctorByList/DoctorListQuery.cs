using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Dtos.Doctors;
using ClinicManagement.Application.Dtos.Patients;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Doctors.DoctorByList
{
    public class DoctorListQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<ResponseDoctorAll>>>
    {
        public DoctorListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
