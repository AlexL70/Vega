using System.Linq;
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

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.FeatureIds, v => v.MapFrom(src =>
                    src.Features.Select(f => f.FeatureId).ToArray()))
                .ForMember(dest => dest.MakeId, v => v.MapFrom(src => src.Model.MakeId));
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(dest => dest.Features, v => v.MapFrom(src =>
                    src.FeatureIds.Select(i => new VehicleFeature {
                        VehicleId = src.Id,
                        FeatureId = i
                        }).ToArray()));
        }
    }
}