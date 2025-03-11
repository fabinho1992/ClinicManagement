using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Patient patient)
        {
            await _unitOfWork.PatientRepository.Add(patient);
            await _unitOfWork.Commit();

            return Ok();
        }
    }
}
