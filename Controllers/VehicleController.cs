using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Core;
using Vega.Core.Models;
using Vega.Core.Models.Resources;

namespace Vega.Controllers
{
    [ApiController] [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _uow;

        public VehicleController(IVehicleRepository repository, IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles() {
            var vehicles = await _repository.GetVehicles();

            return Ok(_mapper.Map<ICollection<Vehicle>, List<VehicleResource>>(vehicles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id) {
            var vehicle = await _repository.GetVehicle(id);

            if(vehicle == null)
                return NotFound($"Vehicle with Id = {id} not found.");

            return Ok(_mapper.Map<Vehicle, VehicleResource>(vehicle));
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleResource), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource dto) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(dto);
            vehicle.LastUpdated = DateTime.UtcNow;
            await _repository.Add(vehicle);
            await _uow.Complete();

            var retObj = await _repository.GetVehicle(vehicle.Id);

            return CreatedAtAction(nameof(GetVehicles), new { id = vehicle.Id },
                _mapper.Map<Vehicle, VehicleResource>(retObj));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VehicleResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource dto) {
            if(dto != null && id != dto.Id) {
                ModelState.AddModelError("Id:", $"Id parameter is {id}, but id of object passed in body is {dto.Id}");
            }
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _repository.GetVehicle(id);
            if(vehicle == null)
                return NotFound($"Vehicle with Id = {id} not found.");

            _mapper.Map<SaveVehicleResource, Vehicle>(dto, vehicle);
            vehicle.LastUpdated = DateTime.UtcNow;

            await _uow.Complete();

            vehicle = await _repository.GetVehicle(id);

            return Ok(_mapper.Map<Vehicle, VehicleResource>(vehicle));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicle(int id) {
            var vehicle = await _repository.GetVehicle(id, includeRelated: false);
            
            if(vehicle == null)
                return NotFound($"Vehicle with Id = {id} not found.");
            
            _repository.Remove(vehicle);
            await _uow.Complete();

            return Ok(id);
        }
    }
}