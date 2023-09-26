using Code9.Domain;
using Code9.Domain.Commands;
using Code9.Domain.Queries;
using Code9WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCinemas")]
        public async Task<ActionResult<List<Cinema>>> GetAllCinemas()
        {
            var query = new GetAllCinemasQuery();
            var cinemas = await _mediator.Send(query);
            return Ok(cinemas);
        }

        [HttpPost("AddCinema")]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            // TODO: Implement
            var command = new AddCinemaCommand()
            {
                Name = addCinemaRequest.Name,
                City = addCinemaRequest.City,
                NumberOfAuditoriums = addCinemaRequest.NumberOfAuditoriums,
                Street = addCinemaRequest.Street
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("UpdateCinema/{id:guid}")]
        public async Task<ActionResult<Cinema>> UpdateCinema([FromRoute]Guid id, UpdateCinemaRequest updateCinemaRequest)
        {
            // TODO: Implement

            return NoContent();
        }

        [HttpDelete("DeleteCinema/{id:guid}")]
        public async Task<IActionResult> DeleteCinema([FromRoute]Guid id)
        {
            // TODO: Implement

            return NoContent();
        }
    }
}
