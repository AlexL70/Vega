namespace Vega.Extensions
{
    public interface IOrderObject
    {
        string SortBy { get; set; }
        bool IsAscending { get; set; }
    }
}