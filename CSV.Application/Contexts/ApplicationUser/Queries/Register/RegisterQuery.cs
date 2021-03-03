using Abp.Domain.Entities;
using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.Contract.Models.RequestModels;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.ApplicationUser.Queries.Register {
    class RegisterQuery {
    }
    public class RegisterQuery {
        private readonly ApplicationDbContext _context;

        public RegisterQuery() {
        }

        public RegisterQuery(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<FilteredResponseViewModel<object>> Register(BaseSearchRequestModel request) {
            try {
                var csvSales = _context
                .CSVSales.OrderBy(x => x.OrderDate)
                .AsNoTracking();

                var totalCount = await csvSales.LongCountAsync();

                if (csvSales == null || totalCount == 0)
                    return new FilteredResponseViewModel<object>();

                var paginatedCSVSales = await csvSales
                    .Paginate(request)
                    .ToListAsync();

                return new FilteredResponseViewModel<object> {
                    Total = totalCount,
                    Length = paginatedCSVSales.Count,
                    Data = paginatedCSVSales
                };
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
