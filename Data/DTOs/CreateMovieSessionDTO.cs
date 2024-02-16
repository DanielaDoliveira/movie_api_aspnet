using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Data.DTOs
{
    public class CreateMovieSessionDTO
    {
        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }
    }
}