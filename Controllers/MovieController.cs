using api_film.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_film.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id = 0;

        [HttpPost]
        public void CreateMovie([FromBody] Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            Console.WriteLine("Movie: " + movie.Title + " Genre: " + movie.Genre + " Duration: " + movie.Duration);
        }

        [HttpGet]
        public IEnumerable<Movie> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return movies.Skip(skip).Take(take);
        }


        [HttpGet("{id}")]
        public Movie? ReadMovieById(int id)
        {
            return movies.FirstOrDefault(movie => movie.Id == id);
        }
    }
}