using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.Contract.Entity;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.Commands.CreateSale {
    public class CreateSaleCommand {
        private readonly ApplicationDbContext _context;

        public CreateSaleCommand() {
        }

        public CreateSaleCommand(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<CreateSaleFilteringResponse<object>> CreateSale(SearchSaleRequestModel request) {
            try {
                var newSale = request.SaleViewModel;
                var addSale = new CSVSale {
                    Region = newSale.Region,
                    Country = newSale.Country,
                    ItemType = newSale.ItemType,
                    SalesChannel = newSale.SalesChannel,
                    OrderPriority = newSale.OrderPriority,
                    OrderDate = newSale.OrderDate,
                    OrderID = newSale.OrderID,
                    ShipDate = newSale.ShipDate,
                    UnitsSold = newSale.UnitsSold,
                    UnitPrice = newSale.UnitPrice,
                    UnitCost = newSale.UnitCost,
                    TotalRevenue = newSale.TotalRevenue,
                    TotalCost = newSale.TotalCost,
                    TotalProfit = newSale.TotalProfit
                };

                _context.CSVSales.Add(addSale);
                await _context.SaveChangesAsync();

                var csvSales = _context.CSVSales
                    .OrderBy(x => x.OrderDate)
                .AsNoTracking();


                var result =  await GetSearchDDLModel.ReturnSales(_context, csvSales, request);
                
                return new CreateSaleFilteringResponse<object> {
                    Total = result.Total,
                    Length = result.Length,
                    Data = result.Data,
                    DropDownLists = result.DropDownLists,
                    NewSaleId = addSale.ID
                };
                
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
