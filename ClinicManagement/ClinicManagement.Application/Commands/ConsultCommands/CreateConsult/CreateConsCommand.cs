using ClinicManagement.Domain.Enuns;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.ConsultCommands.CreateConsult
{
    public class CreateConsCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreateConsCommand(Guid patientId, Guid doctorId, Guid serviceId, 
            string convention, DateTime start, DateTime finish, TypeTreatment typeTreatment)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceId = serviceId;
            Convention = convention;
            Start = start;
            Finish = finish;
            TypeTreatment = typeTreatment;
        }

        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid ServiceId { get; private set; }
        public string Convention { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }
        public TypeTreatment TypeTreatment { get; private set; }
    }
}
