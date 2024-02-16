
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Models;

public class MovieTheater
{
    [Key][Required] public int Id { get; set; }
    [Required(ErrorMessage = "The name field is required")] public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<MovieSession> MovieSessions { get; set; }
}