using System.Collections.Generic;

namespace Vega.Models.Dto
{
    public class MakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ModelDto> Models { get; set; }

        public MakeDto() => Models = new List<ModelDto>();
    }
}