using System.Collections.Generic;

namespace Vega.Models.Dto
{
    public class MakeDto : KeyValuePairDto
    {
        public IList<KeyValuePairDto> Models { get; set; }

        public MakeDto() => Models = new List<KeyValuePairDto>();
    }
}