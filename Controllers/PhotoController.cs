using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vega.Common;
using Vega.Core;
using Vega.Core.Models;
using Vega.Core.Models.Resources;

namespace Vega.Controllers {
    [Route ("/api/vehicles/{vehicleId}/photos")]
    public class PhotoController : Controller {
        private readonly IHostingEnvironment _hostEnv;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        private readonly PhotoSettings _settings;
        private readonly IPhotoService _photoService;

        public PhotoController (IHostingEnvironment hostEnv,
            IVehicleRepository vehicleRepository,
            IPhotoRepository photoRepository,
            IPhotoService photoService, IMapper mapper,
            IOptionsSnapshot<PhotoSettings> options) {
            this._mapper = mapper;
            this._settings = options.Value;
            this._vehicleRepository = vehicleRepository;
            this._photoRepository = photoRepository;
            this._hostEnv = hostEnv;
            this._photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload (int vehicleId, IFormFile file) {
            var vehicle = await _vehicleRepository.GetVehicle (vehicleId, includeRelated : false);
            if (vehicle == null)
                return NotFound ($"Vehicle with Id = {vehicleId} not found.");

            if (file == null)
                return BadRequest("Null file.");
            if (file.Length == 0)
                return BadRequest("Empty file.");
            if (file.Length > _settings.MaxBytes)
                return BadRequest($"File is too big. Max size alowed is {_settings.MaxBytes} bytes.");
            if(!_settings.IsAcceptedFileType(file.FileName))
                return BadRequest($"Invalid file type.");

            var photo = await _photoService.UploadPhoto(vehicle, _hostEnv.WebRootPath, file);

            return Ok(_mapper.Map<Photo, PhotoResource>(photo));
        }

        public async Task<IEnumerable<PhotoResource>> GetPhotos(int vehicleId) {
            var photos = await _photoRepository.GetPhotos(vehicleId);
            return _mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }
    }
}