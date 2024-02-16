using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_film.Data;
using api_film.Data.DTOs;
using api_film.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_film.Controllers;
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDTO addressDTO)
    {
        Address address = _mapper.Map<Address>(addressDTO);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecoverAddressByID), new { Id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDTO> RecoverAddress()
    {
        return _mapper.Map<List<ReadAddressDTO>>(_context.Addresses);
    }

    [HttpGet("{id}")]
    public IActionResult RecoverAddressByID(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address != null)
        {
            ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);
            return Ok(addressDTO);
        }
        else
        {
            return NotFound();
        }

    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map(addressDTO, address);
            _context.SaveChanges();
            return NoContent();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null)
            return NotFound();
        else
        {
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}