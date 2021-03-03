using Abp.Domain.Entities;
using Abp.Extensions;
using Castle.Core.Internal;
using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.DAL;
using CSVApp.Utils.LinqExtensions.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.Commands.Update {

    public class UpdateSaleCommand {
        private readonly ApplicationDbContext _context;

        public UpdateSaleCommand() {
        }

        public UpdateSaleCommand(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<SalesFilteredResponse<object>> UpdateSale(UpdateSaleRequestModel request) {
            try {
                var updateSale = request.SaleViewModel;

                var changedSale = _context
                    .CSVSales
                    .FirstOrDefault(u => u.ID == updateSale.ID);

                if (changedSale == null)
                    throw new EntityNotFoundException();

                changedSale.Region = updateSale.Region;
                changedSale.Country = updateSale.Country;
                changedSale.ItemType = updateSale.ItemType;
                changedSale.SalesChannel = updateSale.SalesChannel;
                changedSale.OrderPriority = updateSale.OrderPriority;
                changedSale.OrderDate = updateSale.OrderDate;
                changedSale.OrderID = updateSale.OrderID;
                changedSale.ShipDate = updateSale.ShipDate;
                changedSale.UnitsSold = updateSale.UnitsSold;
                changedSale.UnitPrice = updateSale.UnitPrice;
                changedSale.UnitCost = updateSale.UnitCost;
                changedSale.TotalRevenue = updateSale.TotalRevenue;
                changedSale.TotalCost = updateSale.TotalCost;
                changedSale.TotalProfit = updateSale.TotalProfit;

                _context.SaveChanges();

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
