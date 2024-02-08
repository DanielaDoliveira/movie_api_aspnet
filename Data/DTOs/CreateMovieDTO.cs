using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_film.Data.DTOs;

public class CreateMovieDTO
{

    [Required(ErrorMessage = "Title is required")]
    [StringLength(50, ErrorMessage = "cannot exceeds 50 characters")]
    public string Title { get; set; }


    [Required(ErrorMessage = "Genre is required")]
    [StringLength(30, ErrorMessage = "Genre cannot exceeds 30 characters")]
    public string Genre { get; set; }


    [Required(ErrorMessage = "Duration is required")]
    [Range(70, 600, ErrorMessage = "Movie duration can between 70 and 600 minutes")]
    public int Duration { get; set; }
}