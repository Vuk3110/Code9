using Code9.Domain.Exceptions;
using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record UpdateCinemaCommand : IRequest<Cinema>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
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
            var cinemaEntity = await _cinemaRepository.GetCinema(request.Id);
            
            if (cinemaEntity is null)
                throw new CinemaNotFoundException($"Cinema with Id: {request.Id} was not found in database.");
            
            cinemaEntity.Name = request.Name;
            cinemaEntity.City = request.City;
            cinemaEntity.Street = request.Street;
            cinemaEntity.NumberOfAuditoriums = request.NumberOfAuditoriums;

            return await _cinemaRepository.UpdateCinema(cinemaEntity);
        }
    }
}
