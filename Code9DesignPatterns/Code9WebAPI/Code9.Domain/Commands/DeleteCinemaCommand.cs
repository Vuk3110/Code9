using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record DeleteCinemaCommand : IRequest<Unit>
    {
        // TODO: Create properties by referencing the Cinema model
        // Keep in mind that this is the delete command, do you really need all the properties?
    }
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Unit>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaCommandHandler(
            ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement this command handler

            return Unit.Value;
        }
    }
}
