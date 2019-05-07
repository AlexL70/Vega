using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Core.Models.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter proper make.")]
        public int? MakeId { get; set; }
        [Required(ErrorMessage = "Please enter proper model.")]
        public int? ModelId { get; set; }
        public bool? IsRegistered { get; set; }

        [Required]
        public ContactResource Contact { get; set; }
        public ICollection<int> FeatureIds { get; set; }

        public SaveVehicleResource()
        {
            FeatureIds = new Collection<int>();
        }
    }
}
