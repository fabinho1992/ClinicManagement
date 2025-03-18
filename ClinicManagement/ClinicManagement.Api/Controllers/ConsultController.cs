using ClinicManagement.Application.Commands.ConsultCommands.CreateConsult;
using ClinicManagement.Application.Commands.DoctorCommands.CreateDoctor;
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

            return Ok();
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new ConsultByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
