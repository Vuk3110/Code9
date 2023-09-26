using Code9.Domain;
using Code9.Domain.Commands;
using Code9.Domain.Queries;
using Code9WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

            var addCinemaCommand = new AddCinemaCommand
            {
                Name = addCinemaRequest.Name,
                City = addCinemaRequest.City,
                Street = addCinemaRequest.Street,
                NumberOfAuditoriums = addCinemaRequest.NumberOfAuditoriums
            };

            var cinema = await _mediator.Send(addCinemaCommand);
            return CreatedAtAction(nameof(GetAllCinemas), new { id = cinema.Id }, cinema);
        }

        [HttpPut("UpdateCinema/{id:guid}")]
        public async Task<ActionResult<Cinema>> UpdateCinema([FromRoute]Guid id, UpdateCinemaRequest updateCinemaRequest)
        {
            var updateCommand = new UpdateCinemaCommand
            {
                Id = id,
                Name = updateCinemaRequest.Name,
                Street = updateCinemaRequest.Street,
                City = updateCinemaRequest.City,
                NumberOfAuditoriums = updateCinemaRequest.NumberOfAuditoriums
            };

            var cinema = await _mediator.Send(updateCommand);
            
            if (cinema is null)
            {
                return NotFound();
            }
            return Ok(cinema);
        }

        [HttpDelete("DeleteCinema/{id:guid}")]
        public async Task<IActionResult> DeleteCinema([FromRoute]Guid id)
        {
            var command = new DeleteCinemaCommand { Id = id };
            
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
