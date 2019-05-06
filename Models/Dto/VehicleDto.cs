using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public KeyValuePairDto Model { get; set; }
        public KeyValuePairDto Make { get; set; }
        public bool? IsRegistered { get; set; }
        public ICollection<KeyValuePairDto> Features { get; set; }
        public ContactDto Contact { get; set; }
        public DateTime LastUpdated { get; set; }

        public VehicleDto()
        {
            Features = new Collection<KeyValuePairDto>();
        }
    }
}