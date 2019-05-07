using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Mapping;
using Vega.Persistence;
using Vega.Core.Models;
using Vega.Core.Models.Resources;

namespace Vega.Controllers
{
    public class ReferenceController : Controller
    {
        private VegaDbContext _context { get; }
        private IMapper _mapper { get; }

        public ReferenceController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes() {
            var makes = await _context.Makes.Include(m => m.Models).OrderBy(m => m.Name)
                .ToListAsync();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures() {
            var features = await  _context.Features
                .OrderBy(f => f.Name)
                .ToListAsync();

            return _mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}