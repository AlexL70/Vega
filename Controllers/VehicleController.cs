using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Models;
using Vega.Models.Dto;

namespace Vega.Controllers
{
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public VehicleController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/vehicles")]
        public async Task<IActionResult> GetVehicles() {
            var vehicles = await _context.Vehicles
                .Include(v => v.Features)
                .Include(v => v.Model).ToListAsync();

            return Ok(_mapper.Map<List<Vehicle>, List<VehicleDto>>(vehicles));
        }

        [HttpGet("/api/vehicles/{id}")]
        public async Task<IActionResult> GetVehicles(int id) {
            var vehicle = await _context.Vehicles
                .Include(v => v.Features)
                .Include(v => v.Model).SingleOrDefaultAsync(v => v.Id == id);

            if(vehicle == null)
                return NotFound();

            return Ok(_mapper.Map<Vehicle, VehicleDto>(vehicle));
        }

        [HttpPost("/api/vehicles")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDto dto) {
            if(!ModelState.IsValid)
                return BadRequest();

            var vehicle = _mapper.Map<VehicleDto, Vehicle>(dto);
            await _context.AddAsync(vehicle);
            dto.Id = await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetVehicles), new { id = dto.Id }, dto);
        }

        [HttpPut("/api/vehicles/{id}")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto dto) {
            if(!ModelState.IsValid)
                return BadRequest();
            if(id != dto.Id)
                return BadRequest();

            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if(vehicle == null)
                return NotFound();

            _mapper.Map<VehicleDto, Vehicle>(dto, vehicle);
            _context.Entry(vehicle).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpDelete("/api/vehicles/{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicle(int id) {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
            
            if(vehicle == null)
                return NotFound($"Vehicle with Id = {id} not found.");
            
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}