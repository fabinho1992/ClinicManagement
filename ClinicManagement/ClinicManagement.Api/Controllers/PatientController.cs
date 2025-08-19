using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Commands.PatientCommands.CreatePatient;
using ClinicManagement.Application.Commands.PatientCommands.DeleteCommand;
using ClinicManagement.Application.Commands.PatientCommands.UpdatePatient;
using ClinicManagement.Application.Queries.Patients;
using ClinicManagement.Application.Queries.Patients.PatientsByCpf;
using ClinicManagement.Application.Queries.Patients.PatientsById;
using ClinicManagement.Application.Queries.Patients.PatientsByList;
using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClinicManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePatCommand command)
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

            //return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new PatientByIdQuery(id);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var query = new PatientByCpfQuery(cpf);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var query = new PatientsLisQuery(paginacao.PageNumber, paginacao.PageSize);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PatientUpdateCommand patientUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(patientUpdate);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePatientCommand command)
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
