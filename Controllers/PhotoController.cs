using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Core;
using Vega.Core.Models;
using Vega.Core.Models.Resources;

namespace Vega.Controllers {
    [Route ("/api/vehicles/{vehicleId}/photos")]
    public class PhotoController : Controller {
        private readonly IHostingEnvironment _hostEnv;

        private readonly string _uploadsFolderPath;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PhotoController (IHostingEnvironment hostEnv,
            IVehicleRepository vehicleRepository,
            IUnitOfWork uow, IMapper mapper) {
            this._mapper = mapper;
            this._uow = uow;
            this._vehicleRepository = vehicleRepository;
            this._hostEnv = hostEnv;
            _uploadsFolderPath = Path.Combine (_hostEnv.WebRootPath, $"uploadedPhotos");
        }

        [HttpPost]
        public async Task<IActionResult> Upload (int vehicleId, IFormFile file) {
            var vehicle = await _vehicleRepository.GetVehicle (vehicleId, includeRelated : false);
            if (vehicle == null)
                return NotFound ($"Vehicle with Id = {vehicleId} not found.");

            var photo = new Photo {
                Id = 0,
                FileName = SaveAndGetRelativePath(vehicleId, file)
            };

            vehicle.Photos.Add (photo);
            await _uow.Complete ();
            return Ok(_mapper.Map<Photo, PhotoResource>(photo));
        }

        private string SaveAndGetRelativePath(int vehicleId, IFormFile file) {
            var path = Path.Combine (_uploadsFolderPath, String.Format("{0,8:D8}", vehicleId));
            if (!Directory.Exists (path))
                Directory.CreateDirectory (path);
            var filePath = Path.Combine (path, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");
            var image = getThumbnail(file.OpenReadStream());
            image.Save (filePath);
            return Path.GetRelativePath(_hostEnv.WebRootPath, filePath);
        }

        private Image getThumbnail(Stream stream)
        {
            var image = Image.FromStream (stream);
            var max = Math.Max(image.Width, image.Height);
            double div = max > 200 ? max / 200.0 : 1.0; // max image dimension is 200
            return image.GetThumbnailImage ( (int)(image.Width / div), (int)(image.Height / div), () => false, IntPtr.Zero);
        }
    }
}