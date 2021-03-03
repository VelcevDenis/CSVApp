using System.Collections.Generic;

namespace CSVApp.Application.Contexts.Sales.Commands.ViewModels {
    public class SalesFilteredResponse<T> where T : class {
        public long Total { get; set; }
        public long Length { get; set; }
        public IEnumerable<T> Data { get; set; }
        public DropDownLists DropDownLists { get; set; }
    }
}
