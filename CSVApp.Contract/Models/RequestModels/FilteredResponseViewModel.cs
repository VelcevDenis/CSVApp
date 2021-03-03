using System;
using System.Collections.Generic;
using System.Text;

namespace CSVApp.Contract.Models.RequestModels {
	public class FilteredResponseViewModel<T> where T : class {
		public long Total { get; set; }
		public long Length { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
