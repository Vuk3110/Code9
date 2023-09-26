using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record AddCinemaCommand : IRequest<Cinema>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
    }

    public class AddCinemaCommandHandler : IRequestHandler<AddCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public AddCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = new Cinema
            {
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                NumberOfAuditoriums = request.NumberOfAuditoriums
            };

            return await _cinemaRepository.AddCinema(cinema);
        }
    }
}
