using ClinicManagement.Application.Dtos.Patients;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Queries.Patients.PatientsByCpf
{
    public class PatientByCpfQuery : IRequest<ResultViewModel<ResponsePatientsDetails>>
    {
        public PatientByCpfQuery(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; private set; }
    }
}
