using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _context;
        public VehicleRepository(VegaDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Vehicle>> GetVehicles(VehicleFilter filter) {
            IQueryable<Vehicle> vDataSet = filter.MakeId.HasValue
                ? _context.Vehicles.Where(v => v.Model.MakeId == filter.MakeId.Value)
                : _context.Vehicles;

            return await vDataSet
                .Include(v => v.Features).ThenInclude(f => f.Feature)
                .Include(v => v.Model).ThenInclude(m => m.Make)
                .ToListAsync();
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true) {
            if(includeRelated)
                return await _context.Vehicles
                    .Include(v => v.Features).ThenInclude(f => f.Feature)
                    .Include(v => v.Model).ThenInclude(m => m.Make)
                    .SingleOrDefaultAsync(v => v.Id == id);

            return await _context.Vehicles.FindAsync(id);
        }

        public async Task Add(Vehicle vehicle) {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Remove(Vehicle vehicle) {
            _context.Remove(vehicle);
        }
    }
}