using System.Linq;
using AutoMapper;
using Vega.Core.Models;
using Vega.Core.Models.Resources;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Domain Model => Resource
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();

            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(dest => dest.FeatureIds, opt => opt.MapFrom(src =>
                    src.Features.Select(f => f.FeatureId).ToArray()))
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.Model.MakeId))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => 
                    new ContactResource {
                        Name = src.ContactName,
                        Email = src.ContactEmail,
                        Phone = src.ContactPhone
                    }));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => 
                    new ContactResource {
                        Name = src.ContactName,
                        Email = src.ContactEmail,
                        Phone = src.ContactPhone
                    }))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features
                    .Select(f => new KeyValuePairResource {
                        Id = f.FeatureId,
                        Name = f.Feature.Name
                    })))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Model.Make));
            CreateMap<VehicleFilter, VehicleFilterResource>();

            //  Resource => Domain Model
            CreateMap<SaveVehicleResource, Vehicle>()
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
            CreateMap<VehicleFilterResource, VehicleFilter>();
        }
    }
}
