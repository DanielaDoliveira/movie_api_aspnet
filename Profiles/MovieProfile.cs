
using AutoMapper;
using api_film.Models;
using api_film.Data.DTOs;

namespace api_film.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDTO, Movie>();
        CreateMap<UpdateMovieDTO, Movie>();
        CreateMap<Movie, UpdateMovieDTO>();
        CreateMap<Movie, ReadMovieDTO>();
    }
}