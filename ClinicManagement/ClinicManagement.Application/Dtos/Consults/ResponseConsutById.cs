using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Consults
{
    internal class ResponseConsutById
    {
        public ResponseConsutById(Guid id, string namePatient, string nameDoctor, string nameService, string convention,
            string dateConsult, string creatAt, string start, string finish, string typeTreatment)
        {
            Id = id;
            NamePatient = namePatient;
            NameDoctor = nameDoctor;
            NameService = nameService;
            Convention = convention;
            DateConsult = dateConsult;
            CreatAt = creatAt;
            Start = start;
            Finish = finish;
            TypeTreatment = typeTreatment;
        }

        public Guid Id { get; set; }
        public string NamePatient { get; set; }
        public string NameDoctor { get; set; }
        public string NameService { get; set; }
        public string Convention { get; set; }
        public string DateConsult { get; set; }
        public string CreatAt { get; private set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public string TypeTreatment { get; set; }
    }
}
