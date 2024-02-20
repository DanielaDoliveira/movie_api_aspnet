using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Models
{
    public class MovieSession
    {

        public int? MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int? MovieTheaterId { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }


}