using CSVApp.Contract.Models.RequestModels;
using System;
using System.Linq;

namespace CSVApp.Utils.LinqExtensions.Pagination {
    public static class PaginationExtensions {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, BaseSearchRequestModel request) {
            try {
                if (request.Start.HasValue)
                    query = query.Skip(request.Start.Value);

                if (request.Limit.HasValue)
                    query = query.Take(request.Limit.Value);

                return query;
            } catch (Exception e) {
                throw new Exception("Was an exception in Paginate", e);
            }
        }
    }
}