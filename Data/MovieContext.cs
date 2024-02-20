
using Microsoft.EntityFrameworkCore;
using api_film.Models;
namespace api_film.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<MovieSession>().HasKey(movieSession => new { movieSession.MovieId, movieSession.MovieTheaterId });
            builder.Entity<MovieSession>().HasOne(movieSession => movieSession.MovieTheater).WithMany(movie => movie.MovieSessions).
            HasForeignKey(movieSession => movieSession.MovieTheaterId);
            builder.Entity<MovieSession>().HasOne(movieSession => movieSession.Movie).WithMany(movie => movie.MovieSessions).
          HasForeignKey(movieSession => movieSession.MovieId);
            builder.Entity<Address>()
            .HasOne(address => address.MovieTheater)
            .WithOne(movieTheater => movieTheater.Address)
            .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }

    }
}