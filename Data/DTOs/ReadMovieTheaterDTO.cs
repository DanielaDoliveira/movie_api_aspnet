
using System.ComponentModel.DataAnnotations;

namespace api_film.Data.DTOs
{
    public class ReadMovieTheaterDTO
    {
        [Key][Required] public int Id { get; set; }
        [Required(ErrorMessage = "The name field is required")] public string Name { get; set; }
        public ReadAddressDTO Address { get; set; }
        public ICollection<ReadMovieSessionDTO> MovieSessions { get; set; }
    }
}