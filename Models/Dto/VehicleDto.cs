using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public ModelDto Model { get; set; }
        public MakeDto Make { get; set; }
        public bool? IsRegistered { get; set; }
        public ICollection<FeatureDto> Features { get; set; }
        public ContactDto Contact { get; set; }
        public DateTime LastUpdated { get; set; }

        public VehicleDto()
        {
            Features = new Collection<FeatureDto>();
        }
    }
}