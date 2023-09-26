using Code9.Domain.Exceptions;
using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record DeleteCinemaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
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
            var cinemaEntity = await _cinemaRepository.GetCinema(request.Id);

            if (cinemaEntity is null)
                throw new CinemaNotFoundException($"Cinema with Id: {request.Id} was not found in database.");
            
            await _cinemaRepository.DeleteCinema(cinemaEntity);

            return Unit.Value;
        }
    }
}
