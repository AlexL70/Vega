using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Dto
{
    public class SaveVehicleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter proper make.")]
        public int? MakeId { get; set; }
        [Required(ErrorMessage = "Please enter proper model.")]
        public int? ModelId { get; set; }
        public bool? IsRegistered { get; set; }

        [Required]
        public ContactDto Contact { get; set; }
        public ICollection<int> FeatureIds { get; set; }

        public SaveVehicleDto()
        {
            FeatureIds = new Collection<int>();
        }
    }
}
