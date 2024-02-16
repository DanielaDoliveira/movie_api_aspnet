
using Microsoft.EntityFrameworkCore;
using api_film.Models;
namespace api_film.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }
    }
}