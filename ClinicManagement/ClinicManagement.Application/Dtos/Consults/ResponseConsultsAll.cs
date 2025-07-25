using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Consults
{
    public class ResponseConsultsAll
    {
        public ResponseConsultsAll(Guid id, string namePatient, string nameDoctor, string nameService,
            string convention, string dateConsult)
        {
            Id = id;
            NamePatient = namePatient;
            NameDoctor = nameDoctor;
            NameService = nameService;
            Convention = convention;
            DateConsult = dateConsult;
        }

        public Guid Id { get; set; }
        public string NamePatient { get; set; }
        public string NameDoctor { get; set; }
        public string NameService { get; set; }
        public string Convention { get; set; }
        public string DateConsult { get; set; }
    }
}
