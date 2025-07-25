using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Commands.DoctorCommands.CreateDoctor;
using ClinicManagement.Application.Commands.DoctorCommands.DeleteCommand;
using ClinicManagement.Application.Commands.DoctorCommands.UpdateDoctor;
using ClinicManagement.Application.Commands.PatientCommands.DeleteCommand;
using ClinicManagement.Application.Commands.PatientCommands.UpdatePatient;
using ClinicManagement.Application.Queries.Doctors.DoctorById;
using ClinicManagement.Application.Queries.Doctors.DoctorByList;
using ClinicManagement.Application.Queries.Patients.PatientsById;
using ClinicManagement.Application.Queries.Patients.PatientsByList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        
        public async Task<IActionResult> Create(CreateDocCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var query = new DoctorListQuery(paginacao.PageNumber, paginacao.PageSize);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new DoctorByIdQuery(id);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DoctorUpdateCommand doctorUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(doctorUpdate);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDoctorCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
