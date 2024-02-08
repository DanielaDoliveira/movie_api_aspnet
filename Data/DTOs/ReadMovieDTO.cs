

namespace api_film.Data.DTOs;

public class ReadMovieDTO
{

    public string Title { get; set; }

    public string Genre { get; set; }

    public int Duration { get; set; }
    public DateTime searchTime { get; set; } = DateTime.Now;
}