﻿using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Commands
{
    public record AddCinemaCommand : IRequest<Cinema>
    {
        // TODO: Create properties by referencing the Cinema model
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
    }

    public class AddCinemaCommandHandler : IRequestHandler<AddCinemaCommand, Cinema>
    {
        // TODO: Implement this command handler
        private readonly ICinemaRepository _repository;

        public AddCinemaCommandHandler(ICinemaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cinema> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = new Cinema()
            {
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                NumberOfAuditoriums = request.NumberOfAuditoriums
            };

            return await _repository.AddCinema(cinema);
        }
    }
}
