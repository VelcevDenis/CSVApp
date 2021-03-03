using Abp.Domain.Entities;
using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.Contract.Models.RequestModels;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.Queries.GetAllSales {

    public class GetAllSalesQuery {
        private readonly ApplicationDbContext _context;

        public GetAllSalesQuery() {
        }

        public GetAllSalesQuery(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<SalesFilteredResponse<object>> GetAllSales(BaseSearchRequestModel request) {
            try {
                var csvSales = _context.CSVSales
                    .OrderBy(x => x.OrderDate)
                .AsNoTracking();

                return await GetSearchDDLModel.ReturnSales(_context, csvSales, request);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
