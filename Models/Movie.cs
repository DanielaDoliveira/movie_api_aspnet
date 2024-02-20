using System.ComponentModel.DataAnnotations;

namespace api_film.Models;

public class Movie
{

  [Key][Required] public int Id { get; set; }
  [Required(ErrorMessage = "Title is required")]
  [MaxLength(50, ErrorMessage = "cannot exceeds 50 characters")]
  public string Title { get; set; }


  [Required(ErrorMessage = "Genre is required")]
  [MaxLength(30, ErrorMessage = "Genre cannot exceeds 30 characters")]
  public string Genre { get; set; }


  [Required(ErrorMessage = "Duration is required")]
  [Range(70, 600, ErrorMessage = "Movie duration can between 70 and 600 minutes")]
  public int Duration { get; set; }
  public virtual ICollection<MovieSession> MovieSessions { get; set; }


}