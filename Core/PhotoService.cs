using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vega.Core.Models;

namespace Vega.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPhotoStorage _photoStorage;

        public PhotoService(IUnitOfWork uow,
            IPhotoStorage photoStorage)
        {
            _uow = uow;
            _photoStorage = photoStorage;
        }
        public async Task<Photo> UploadPhoto(Vehicle vehicle, string uploadsRoot, IFormFile file)
        {
            var photo = new Photo {
                Id = 0,
                FileName = _photoStorage.StorePhoto(vehicle, uploadsRoot, file)
            };

            vehicle.Photos.Add (photo);
            await _uow.Complete ();
            return photo;
        }
    }
}