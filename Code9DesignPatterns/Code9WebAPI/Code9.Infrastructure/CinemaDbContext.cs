using Code9.Domain;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(new List<Cinema>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Novi Sad",
                    Name = "Cinestar",
                    NumberOfAuditoriums = 15,
                    Street = "Bulevar Oslobodjenja 25",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Novi Sad",
                    Name = "Cinemania",
                    NumberOfAuditoriums = 5,
                    Street = "Bulevar Evrope 8"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Zrenjanin",
                    Name = "Cinestar",
                    NumberOfAuditoriums = 21,
                    Street = "Igmanska 52a"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Beograd",
                    Name = "Superstar",
                    NumberOfAuditoriums = 36,
                    Street = "Bulevar Oslobodjenja 1032"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Beograd",
                    Name = "Arena",
                    NumberOfAuditoriums = 2,
                    Street = "Nikole Pasica 22"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    City = "Beograd",
                    Name = "Trzni centar Galerija",
                    NumberOfAuditoriums = 5,
                    Street = "Novosadski put 90"
                }
            });
        }
    }
}