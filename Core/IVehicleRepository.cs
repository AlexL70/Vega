using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery query);
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        Task Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}