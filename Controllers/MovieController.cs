using api_film.Data;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

    /// <summary>
    /// Add a movie to Database
    /// </summary>
    /// <param name="movieDTO">Object with necessary fields to create a movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Object created with successful</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]

    public IActionResult CreateMovie([FromBody] CreateMovieDTO movieDTO)
    {
        Movie movie = _mapper.Map<Movie>(movieDTO);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieById), new { id = movie.Id }, movie);

    }

    /// <summary>
    /// Read all movies. If the user not pass a param to skip/take the default is show the first ten results
    /// </summary>
    /// <param name="movieDTO">Object with necessary fields to create a movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Ok</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadMovieDTO> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 10, [FromQuery] string? cineName = null)
    {
        if (cineName == null)
        {
            return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadMovieDTO>>(_context.Movies
        .Skip(skip)
        .Take(take)
        .Where(movie => movie.MovieSessions
                .Any(movieSession => movieSession.MovieTheater.Name == cineName)
            ).
        ToList());
    }

    /// <summary>
    /// Read movies by id passed by user as param
    /// </summary>
    /// <param name="id">Object id</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Ok</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult? ReadMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
            return NotFound();
        else
        {
            var movieDTO = _mapper.Map<ReadMovieDTO>(movie);

            return Ok(movieDTO);
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

    [HttpPatch("{id}")]
    public IActionResult UpdatePatchMovie(int id, JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        var movieToUpdate = _mapper.Map<UpdateMovieDTO>(movie);
        patch.ApplyTo(movieToUpdate, ModelState);
        if (!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        else
        {
            _mapper.Map(movieToUpdate, movie);
            _context.SaveChanges();
            return NoContent();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movies => movies.Id == id);
        if (movie == null)
            return NotFound();
        else
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }




}