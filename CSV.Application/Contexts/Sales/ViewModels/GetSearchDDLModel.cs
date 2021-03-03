using CSVApp.Contract.Entity;
using CSVApp.Contract.Models.RequestModels;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.ViewModels {
    public static class GetSearchDDLModel {
        public static async Task<SalesFilteredResponse<object>> ReturnSales(ApplicationDbContext _context, IQueryable<CSVSale> csvSales, BaseSearchRequestModel request) {
            try {                

                var totalCount = await csvSales.LongCountAsync();

                var countrys = await _context
                .Countrys.Select(p => p.Value)
                    .Distinct()
                    .ToListAsync();

                var itemTypes = await _context
                .ItemTypes.Select(p => p.Value)
                    .Distinct()
                    .ToListAsync();

                var regions = await _context
                .Regions.Select(p => p.Value)
                    .Distinct()
                    .ToListAsync();

                var salesChannels = await _context
                .SalesChannels.Select(p => p.Value)
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
