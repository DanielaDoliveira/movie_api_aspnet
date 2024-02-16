using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;

namespace api_film.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();

        }
    }
}