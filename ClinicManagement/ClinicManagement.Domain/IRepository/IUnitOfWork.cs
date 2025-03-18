using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository
{
    public interface IUnitOfWork
    {
        IServiceRepository ServiceRepository { get; }
        IPatientRepository PatientRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IConsulRepository ConsultRepository { get; }
        IAddressRepository AddressRepository { get; }
        Task Commit();
    }
}
