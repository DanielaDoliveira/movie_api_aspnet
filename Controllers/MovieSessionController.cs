using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_film.Data;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_film.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieSessionController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieSessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AddMovieSession(CreateMovieSessionDTO dto)
    {
        MovieSession movieSession = _mapper.Map<MovieSession>(dto);
        _context.MovieSessions.Add(movieSession);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecoverMovieSessionByID), new { Id = movieSession.Id }, movieSession);
    }
    [HttpGet]
    public IEnumerable<ReadMovieSessionDTO> RecoverMovieSession()
    {
        return _mapper.Map<List<ReadMovieSessionDTO>>(_context.MovieSessions.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecoverMovieSessionByID(int id)
    {
        MovieSession movieSession = _context.MovieSessions.FirstOrDefault(movieSession => movieSession.Id == id);
        if (movieSession != null)
        {
            ReadMovieSessionDTO movieSessionDTO = _mapper.Map<ReadMovieSessionDTO>(movieSession);
            return Ok(movieSessionDTO);
        }


        return NotFound();


    }



}