using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter proper make.")]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Please enter proper model.")]
        public int ModelId { get; set; }
        public bool? IsRegistered { get; set; }
        public ICollection<int> FeatureIds { get; set; }
        [Required][StringLength(255)]
        public string ContactName { get; set; }
        [Required][StringLength(255)]
        public string ContactPhone { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }

        public VehicleDto()
        {
            FeatureIds = new Collection<int>();
        }
    }
}
