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
                .ForMember(dest => dest.FeatureIds, opt => opt.MapFrom(src =>
                    src.Features.Select(f => f.FeatureId).ToArray()))
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.Model.MakeId))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => 
                    new ContactDto {
                        Name = src.ContactName,
                        Email = src.ContactEmail,
                        Phone = src.ContactPhone
                    }));
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src =>
                    src.FeatureIds.Select(i => new VehicleFeature {
                        VehicleId = src.Id,
                        FeatureId = i
                        }).ToArray()))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Contact.Phone))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.Contact.Email));
        }
    }
}