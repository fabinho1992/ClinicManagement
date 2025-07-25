using ClinicManagement.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Models
{
    public class Consult
    {
        public Consult(Guid patientId, Guid doctorId, Guid? serviceId, string convention,
            DateTime start, DateTime finish, TypeTreatment typeTreatment)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceId = serviceId;
            Convention = convention;
            Start = start;
            Finish = finish;
            TypeTreatment = typeTreatment;
            CreatAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid? ServiceId { get; private set; }
        public string Convention { get; private set; }
        public DateTime CreatAt { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }
        public TypeTreatment TypeTreatment { get; private set; }
        public virtual Service? Service { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
