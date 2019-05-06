using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Models;
using Vega.Models.Dto;
using Vega.Mapping;
using Vega.Persistence;

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
        public async Task<IEnumerable<MakeDto>> GetMakes() {
            var makes = await _context.Makes.Include(m => m.Models).OrderBy(m => m.Name)
                .ToListAsync();

            return _mapper.Map<List<Make>, List<MakeDto>>(makes);
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairDto>> GetFeatures() {
            var features = await  _context.Features
                .OrderBy(f => f.Name)
                .ToListAsync();

            return _mapper.Map<List<Feature>, List<KeyValuePairDto>>(features);
        }
    }
}