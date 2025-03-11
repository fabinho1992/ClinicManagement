using ClinicManagement.Domain.IRepository;
using ClinicManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceRepository? _serviceRepository;
        private IPatientRepository? _patientRepository;
        private IDoctorRepository? _dctorRepository;
        private ITreatmentRepository? _treatmentRepository;
        private IAddressRepository? _addressRepository;

        private readonly ClinicDbContext _context;

        public UnitOfWork(ClinicDbContext context)
        {
            _context = context;
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                return _serviceRepository = _serviceRepository ?? new ServiceRepository(_context, _context);
            }
        }

        public IPatientRepository PatientRepository
        {
            get
            {
                return _patientRepository = _patientRepository ?? new PatientRepository(_context, _context);
            }
        }

        public IDoctorRepository DoctorRepository
        {
            get
            {
                return _dctorRepository = _dctorRepository ?? new DoctorRepository(_context, _context);
            }
        }

        public ITreatmentRepository TreatmentRepository
        {
            get
            {
                return _treatmentRepository = _treatmentRepository ?? new TreatmentRepository(_context, _context);
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return _addressRepository = _addressRepository ?? new AddressRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
