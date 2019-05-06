using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Persistence
{
    public interface IVehicleRepository
    {
        Task<ICollection<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        Task Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}