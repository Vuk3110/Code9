using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record UpdateCinemaCommand : IRequest<Cinema>
    {
        // TODO: Create properties by referencing the Cinema model
    }

    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaCommandHandler(
            ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement this command handler

            throw new NotImplementedException();
        }
    }
}
