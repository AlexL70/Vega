using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Models;
using Vega.Models.Dto;

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
        public IEnumerable<MakeDto> GetMakes() {
            var makes = _context.Makes.Include(m => m.Models).OrderBy(m => m.Name)
                .Select(_mapper.Map<Make, MakeDto>)
                .ToList();

            return makes;
        }

        [HttpGet("/api/features")]
        public IEnumerable<FeatureDto> GetFeatures() {
            return  _context.Features
                .OrderBy(f => f.Name)
                .Select(_mapper.Map<Feature, FeatureDto>)
                .ToList();
        }
    }
}