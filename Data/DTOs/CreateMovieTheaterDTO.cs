using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Data.DTOs;

public class CreateMovieTheaterDTO
{
    [Required(ErrorMessage = "The name field is required")] public string Name { get; set; }
    public int AddressID { get; set; }
}