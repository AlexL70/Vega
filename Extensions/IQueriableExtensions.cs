using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Vega.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query,
            IOrderObject orderObj,
            Dictionary<string, Expression<Func<T, object>>> orderMapping)
        {
            if (orderMapping.ContainsKey(orderObj?.SortBy?.ToLower() ?? "")) {
                var lambda = orderMapping[orderObj.SortBy.ToLower()];
                if(lambda != null)
                    query = orderObj.IsAscending
                        ? query.OrderBy(lambda)
                        : query.OrderByDescending(lambda);
            }
            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query,
            IPageObject pageObj) 
        {
            var page = pageObj.Page <= 0 ? 1 : pageObj.Page;
            var pageSize = pageObj.PageSize <= 0 ? 10 : pageObj.PageSize;

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}