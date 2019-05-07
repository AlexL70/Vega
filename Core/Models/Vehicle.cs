using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool? IsRegistered { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }
        public DateTime LastUpdated { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}