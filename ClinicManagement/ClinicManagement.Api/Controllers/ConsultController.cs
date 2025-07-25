using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Application.Commands.ConsultCommands.CreateConsult;
using ClinicManagement.Application.Commands.DoctorCommands.CreateDoctor;
using ClinicManagement.Application.Queries.Consults.CnosultsGetAll;
using ClinicManagement.Application.Queries.Consults.ConsultByDate;
using ClinicManagement.Application.Queries.Consults.ConsultsById;
using ClinicManagement.Application.Queries.Patients.PatientsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateConsCommand command)
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

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new ConsultByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var query = new ConsultsGetAllQuery(paginacao.PageNumber, paginacao.PageSize);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("Get-date")]
        public async Task<IActionResult> GetAllDate(DateTime date)
        {
            var query = new ConsultGetDateQuery(date);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
