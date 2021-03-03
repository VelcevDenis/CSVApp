using CSVApp.Contract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVApp.Application.Contexts.Sales.Commands.ViewModels {
    public class CreateSaleFilteringResponse<T> where T : class {
        public long Total { get; set; }
        public long Length { get; set; }
        public IEnumerable<T> Data { get; set; }
        public DropDownLists DropDownLists { get; set; }
        public long NewSaleId { get; set; }
    }
}
