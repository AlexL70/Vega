using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Vega.Models;
using Vega.Models.Dto;

namespace Vega
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<Model, ModelDto>()
                .ForMember(m => m.MakeId, opt => opt.MapFrom(m => m.Make.Id));
            CreateMap<Make, MakeDto>();
        }
    }
}