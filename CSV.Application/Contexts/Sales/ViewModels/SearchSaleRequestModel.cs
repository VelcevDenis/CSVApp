using CSVApp.Contract.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVApp.Application.Contexts.Sales.Commands.ViewModels {
    public class SearchSaleRequestModel : BaseSearchRequestModel {
        public SaleViewModel SaleViewModel { get; set; }
    }
}
