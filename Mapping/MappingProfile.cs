using AutoMapper;
using Vega.Models;
using Vega.Models.Dto;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<Model, ModelDto>();
            CreateMap<Make, MakeDto>();
        }
    }
}