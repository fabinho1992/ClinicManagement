using ClinicManagement.Application.Dtos.Doctors;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Doctors.DoctorById
{
    public class DoctorByIdQuery : IRequest<ResultViewModel<ResponseDoctorById>>
    {
        public DoctorByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
