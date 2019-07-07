using Microsoft.AspNetCore.Http;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IPhotoStorage
    {
         string StorePhoto(Vehicle vehicle, string uploadsRoot, IFormFile file);
    }
}