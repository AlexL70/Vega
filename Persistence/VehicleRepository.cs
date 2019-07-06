using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;
using Vega.Core.Models.Resources;
using Vega.Extensions;

namespace Vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _context;
        public VehicleRepository(VegaDbContext context)
        {
            _context = context;
        }

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj) {
            IQueryable<Vehicle> query = _context.Vehicles;

            query = query.ApplyFiltering(queryObj);

            var count = await query.CountAsync();

            query = query
                .Include(v => v.Features).ThenInclude(f => f.Feature)
                .Include(v => v.Model).ThenInclude(m => m.Make)
                .AsQueryable();

            var orderMapping = new Dictionary<string, Expression<Func<Vehicle, object>>> {
                [nameof(VehicleResource.Make).ToLower()] = v => v.Model.Make.Name,
                [nameof(VehicleResource.Model).ToLower()] = v => v.Model.Name,
                [nameof(Vehicle.ContactName).ToLower()] = v => v.ContactName,
                [nameof(Vehicle.Id).ToLower()] = v => v.Id
            };
            query = query.ApplyOrdering(queryObj, orderMapping);

            query = query.ApplyPaging(queryObj);

            return new QueryResult<Vehicle> {
                TotalItems = count,
                Items = await query.ToListAsync()
            };
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true) {
            if(includeRelated)
                return await _context.Vehicles
                    .Include(v => v.Features).ThenInclude(f => f.Feature)
                    .Include(v => v.Model).ThenInclude(m => m.Make)
                    .Include(v => v.Photos)
                    .SingleOrDefaultAsync(v => v.Id == id);

            return await _context.Vehicles.Include(v => v.Photos)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task Add(Vehicle vehicle) {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Remove(Vehicle vehicle) {
            _context.Remove(vehicle);
        }
    }
}