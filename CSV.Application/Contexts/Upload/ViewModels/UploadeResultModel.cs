using System;
using System.Collections.Generic;
using System.Text;

namespace CSVApp.Application.Contexts.Upload.ViewModels {
    public class UploadeResultModel {
        public int SuccessfullyAddedRows { get; set; }
        public int FailedRows { get; set; }

        public int DublicatesRows { get; set; }
    }
}
