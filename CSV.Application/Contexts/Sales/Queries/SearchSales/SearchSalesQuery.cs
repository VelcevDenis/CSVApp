using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.Contract.Models.RequestModels;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.Queries.SearchSales {
    public class SearchSalesQuery {
        private readonly ApplicationDbContext _context;

        public SearchSalesQuery() {
        }

        public SearchSalesQuery(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<SalesFilteredResponse<object>> SearchSales(SearchSaleRequestModel request) {
            try {
                var saleViewModel = request.SaleViewModel;
                var csvSales = _context.CSVSales
                .OrderBy(x => x.OrderDate)
                .AsNoTracking();

                if (saleViewModel.ID > 0) {
                    csvSales = csvSales.Where(x => x.ID == saleViewModel.ID);
                }
                if (!String.IsNullOrEmpty(saleViewModel.Region)) {
                    csvSales = csvSales.Where(x => x.Region == saleViewModel.Region);
                }
                if (!String.IsNullOrEmpty(saleViewModel.Country)) {
                    csvSales = csvSales.Where(x => x.Country == saleViewModel.Country);
                }
                if (!String.IsNullOrEmpty(saleViewModel.ItemType)) {
                    csvSales = csvSales.Where(x => x.ItemType == saleViewModel.ItemType);
                }
                if (!String.IsNullOrEmpty(saleViewModel.SalesChannel)) {
                    csvSales = csvSales.Where(x => x.SalesChannel == saleViewModel.SalesChannel);
                }
                if (!String.IsNullOrEmpty(saleViewModel.OrderPriority)) {
                    csvSales = csvSales.Where(x => x.OrderPriority == saleViewModel.OrderPriority);
                }
                if (saleViewModel.OrderID > 0) {
                    csvSales = csvSales.Where(x => x.OrderID == saleViewModel.OrderID);
                }

                var totalCount = await csvSales.LongCountAsync();

                var countrys = await _context
                .CSVSales.Select(p => p.Country)
                .OrderBy(x => x)
                .Distinct()
                .ToListAsync();

                var itemTypes = await _context
                .CSVSales.Select(p => p.ItemType)
                .OrderBy(x => x)
                .Distinct()
                .ToListAsync();

                var regions = await _context
                .CSVSales.Select(p => p.Region)
                .OrderBy(x => x)
                .Distinct()
                .ToListAsync();

                var salesChannels = await _context
                .CSVSales.Select(p => p.SalesChannel)
                .OrderBy(x => x)
                .Distinct()
                .ToListAsync();

                if (csvSales == null || totalCount == 0)
                    return new SalesFilteredResponse<object>();

                var paginatedCSVSales = await csvSales
                    .Paginate(request)
                    .ToListAsync();

                return new SalesFilteredResponse<object> {
                    Total = totalCount,
                    Length = paginatedCSVSales.Count,
                    Data = paginatedCSVSales,
                    DropDownLists = new DropDownLists() {
                        CountryList = countrys,
                        ItemTypeList = itemTypes,
                        RegionList = regions,
                        SalesChannelList = salesChannels
                    }
                };
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
