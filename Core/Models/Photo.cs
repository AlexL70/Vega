using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        [Required] [StringLength(255)]
        public string FileName { get; set; }
    }
}