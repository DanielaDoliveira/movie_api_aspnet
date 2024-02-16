
using System.ComponentModel.DataAnnotations;


namespace api_film.Data.DTOs;

public class UpdateMovieTheaterDTO
{
    [Required(ErrorMessage = "The name field is required")] public string Name { get; set; }
}