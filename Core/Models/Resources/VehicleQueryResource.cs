namespace Vega.Core.Models.Resources
{
    public class VehicleQueryResource
    {
        public int? MakeId { get; set; }

        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}