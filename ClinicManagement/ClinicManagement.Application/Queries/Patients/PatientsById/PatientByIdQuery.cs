using ClinicManagement.Application.Dtos.Patients;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Patients.PatientsById
{
    public class PatientByIdQuery : IRequest<ResultViewModel<ResponsePatientsDetails>>
    {
        public PatientByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
