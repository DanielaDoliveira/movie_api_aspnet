
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;

namespace api_film.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDTO, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDTO>().ForMember(movieTheaterDTO => movieTheaterDTO.Address,
                opt => opt.MapFrom(movieTheater => movieTheater.Address)).ForMember(movieTheaterDTO => movieTheaterDTO.MovieSessions,
                           opt => opt.MapFrom(movieTheater => movieTheater.MovieSessions));
            CreateMap<UpdateMovieTheaterDTO, MovieTheater>();
        }
    }
}