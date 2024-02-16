using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace api_film.Data.DTOs
{
    public class CreateAddressDTO
    {
        [Required] public string AddressName { get; set; }
        [Required] public int Number { get; set; }
    }
}