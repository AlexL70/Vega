using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Controllers
{
    public class ReferenceController : Controller
    {
        private VegaDbContext _context;

        public ReferenceController(VegaDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes() {
            return await _context.Makes.OrderBy(m => m.Name).ToListAsync();
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<Feature>> GetFeatures() {
            return await _context.Features.OrderBy(m => m.Name).ToListAsync();
        }
    }
}