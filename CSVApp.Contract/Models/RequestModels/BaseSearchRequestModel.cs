namespace CSVApp.Contract.Models.RequestModels {
	public class BaseSearchRequestModel {
		public int? Start { get; set; }
		public int? Limit { get; set; }
		public string SortBy { get; set; } = "OrderDate";
		public string SortType { get; set; } = "DESC";
	}
}
