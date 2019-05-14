using Vega.Extensions;
namespace Vega.Core.Models
{
    public class VehicleQuery : IOrderObject, IPageObject
    {
        public int? MakeId { get; set; }
        
        #region IOrderObject implementation
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
        #endregion

        #region IPageObject implementation
        public int Page { get; set; }
        public int PageSize { get; set; }
        #endregion
    }
}