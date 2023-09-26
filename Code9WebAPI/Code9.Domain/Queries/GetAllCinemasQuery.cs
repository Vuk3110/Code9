using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Queries
{
    public record GetAllCinemasQuery : IRequest<List<Cinema>>;

    public class GetAllCinemasQueryHandler : IRequestHandler<GetAllCinemasQuery, List<Cinema>>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public GetAllCinemasQueryHandler(
            ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<List<Cinema>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetAllCinemas();
        }
    }
}
