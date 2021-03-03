using Abp.Domain.Entities;
using CSVApp.DAL;
using System;
using System.Linq;

namespace CSVApp.Application.Contexts.Sales.Commands.Commands.DeleteSale {
    public class DeleteSaleCommand {
        private readonly ApplicationDbContext _context;

        public DeleteSaleCommand() {
        }

        public DeleteSaleCommand(ApplicationDbContext context) {
            _context = context;
        }

        public bool DeleteSale(long request) {
            try {
                var removedSale = _context
                .CSVSales
                .FirstOrDefault(u => u.ID == request);

                if (removedSale == null)
                    throw new EntityNotFoundException();

                _context.CSVSales.Remove(removedSale);
                _context.SaveChanges();

                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
