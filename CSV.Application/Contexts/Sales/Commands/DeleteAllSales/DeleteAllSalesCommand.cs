using CSVApp.DAL;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Sales.Commands.DeleteAllSales {
    public class DeleteAllSalesCommand {
        private readonly ApplicationDbContext _context;

        public DeleteAllSalesCommand() {
        }

        public DeleteAllSalesCommand(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<bool> DeleteAllSale() {
            try {
                var allSales = await _context.CSVSales.ToListAsync();
                _context.BulkDelete(allSales);
                return true;

            } catch (Exception ex) {
                throw ex;
            }            
        }
    }
}
