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

            CreateMap<Vehicle, SaveVehicleDto>()
                .ForMember(dest => dest.FeatureIds, opt => opt.MapFrom(src =>
                    src.Features.Select(f => f.FeatureId).ToArray()))
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.Model.MakeId))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => 
                    new ContactDto {
                        Name = src.ContactName,
                        Email = src.ContactEmail,
                        Phone = src.ContactPhone
                    }));
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => 
                    new ContactDto {
                        Name = src.ContactName,
                        Email = src.ContactEmail,
                        Phone = src.ContactPhone
                    }))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features
                    .Select(f => new FeatureDto {
                        Id = f.FeatureId,
                        Name = f.Feature.Name
                    })))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => new MakeDto {
                        Id = src.Model.MakeId,
                        Name = src.Model.Make.Name
                    }));

            CreateMap<SaveVehicleDto, Vehicle>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Contact.Phone))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Features, opt => opt.Ignore())
                .AfterMap((vd, v) => {
                    //  Remove from Model features which do not exist in DTO
                    var featuresToRemove = v.Features.Where(f => !vd.FeatureIds.Contains(f.FeatureId)).ToArray();
                    foreach(var feature in featuresToRemove)
                        v.Features.Remove(feature);
                    //  Add features which exist in DTO, but do not exist in Model
                    var featuresToAdd = vd.FeatureIds.Where(f =>
                        !v.Features.Any(vf => vf.FeatureId == f))
                            .Select(f => new VehicleFeature {
                                FeatureId = f,
                                VehicleId = v.Id })
                            .ToArray();
                    foreach(var feature in featuresToAdd)
                        v.Features.Add(feature);
                });
        }
    }
}
