using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_film.Data.DTOs
{
    public class UpdateAddressDTO
    {
        [Required] public string AddressName { get; set; }
        [Required] public int Number { get; set; }
    }
}