using api_film.Data;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api_film.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;
    public MovieTheaterController(MovieContext context, IMapper mapper)

    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateMovieTheater([FromBody] CreateMovieTheaterDTO movieTheaterDTO)
    {
        MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDTO);
        _context.MovieTheaters.Add(movieTheater);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieTheaterById), new { Id = movieTheater.Id }, movieTheaterDTO);

    }
    [HttpGet]
    public IEnumerable<ReadMovieTheaterDTO> ReadMovieTheater([FromQuery] int? addressid = null)
    {
        if (addressid == null)
        {
            return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.MovieTheaters.ToList());
        }

        return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.MovieTheaters
        .FromSqlRaw($"SELECT Id, Name,AddressId FROM MovieTheaters WHERE MovieTheaters.AddressId = {addressid}")
        .ToList());


    }
    [HttpGet("{id}")]
    public IActionResult ReadMovieTheaterById(int id)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault((movieTheater => movieTheater.Id == id));
        if (movieTheater != null)
        {
            ReadMovieTheaterDTO movieTheaterDTO = _mapper.Map<ReadMovieTheaterDTO>(movieTheater);
            return Ok(movieTheaterDTO);

        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDTO movieTheaterDTO)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheaterDTO => movieTheaterDTO.Id == id);
        if (movieTheater == null)
            return NotFound();

        _mapper.Map(movieTheaterDTO, movieTheater);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault((movieTheater => movieTheater.Id == id));
        if (movieTheater == null)
            return NotFound();

        _context.Remove(movieTheater);
        _context.SaveChanges();
        return NoContent();
    }
}
