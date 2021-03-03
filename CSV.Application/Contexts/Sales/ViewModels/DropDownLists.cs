using System;
using System.Collections.Generic;
using System.Text;

namespace CSVApp.Application.Contexts.Sales.Commands.ViewModels {
    public class DropDownLists {
        public IEnumerable<string> RegionList { get; set; }
        public IEnumerable<string> CountryList { get; set; }
        public IEnumerable<string> ItemTypeList { get; set; }
        public IEnumerable<string> SalesChannelList { get; set; }
    }
}
