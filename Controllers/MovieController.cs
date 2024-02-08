using api_film.Data;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_film.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieDTO movieDTO)
    {
        Movie movie = _mapper.Map<Movie>(movieDTO);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieById), new { id = movie.Id }, movie);

    }

    [HttpGet]
    public IEnumerable<Movie> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Movies.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult? ReadMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(movie);
        }

    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

    }
}