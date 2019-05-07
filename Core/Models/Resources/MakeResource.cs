using System.Collections.Generic;

namespace Vega.Core.Models.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        public IList<KeyValuePairResource> Models { get; set; }

        public MakeResource() => Models = new List<KeyValuePairResource>();
    }
}