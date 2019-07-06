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

        public PhotoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Photo> UploadPhoto(Vehicle vehicle, string uploadsRoot, IFormFile file)
        {
          var uploadsFolderPath = Path.Combine ( uploadsRoot, $"uploadedPhotos");
          var path = Path.Combine (uploadsFolderPath, String.Format("{0,8:D8}", vehicle.Id));
            if (!Directory.Exists (path))
                Directory.CreateDirectory (path);
            var filePath = Path.Combine (path, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");
            var image = getThumbnail(file.OpenReadStream());
            image.Save (filePath);

            var photo = new Photo {
                Id = 0,
                FileName = Path.GetRelativePath(uploadsRoot, filePath)
            };

            vehicle.Photos.Add (photo);
            await _uow.Complete ();
            return photo;
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