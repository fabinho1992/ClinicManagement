using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Dtos.Consults
{
    public class RespConsultDoctor
    {
        public string NamePatient { get; set; }
        public string NameService { get; set; }
        public string Convention { get; set; }
        public string DateConsult { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public string TypeTreatment { get; set; }
    }
}
