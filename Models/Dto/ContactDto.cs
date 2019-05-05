using System.ComponentModel.DataAnnotations;

namespace Vega.Models.Dto
{
    public class ContactDto {
        [Required][StringLength(255)]
        public string Name { get; set; }
        [Required][StringLength(255)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
