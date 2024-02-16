using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required] public string AddressName { get; set; }
        [Required] public int Number { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }
}