using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSVApp.Contract.Entity {
    public class CSVSale {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(70)")]
        public string Region { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string ItemType { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SalesChannel { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string OrderPriority { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "bigint")]
        public long OrderID { get; set; }
        [Column(TypeName = "date")]
        public DateTime ShipDate { get; set; }
        [Column(TypeName = "bigint")]
        public int UnitsSold { get; set; }
        [Column(TypeName = "decimal(25,12)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(25,12)")]
        public decimal UnitCost { get; set; }
        [Column(TypeName = "decimal(25,12)")]
        public decimal TotalRevenue { get; set; }
        [Column(TypeName = "decimal(25,12)")]
        public decimal TotalCost { get; set; }
        [Column(TypeName = "decimal(25,12)")]
        public decimal TotalProfit { get; set; }
    }
}
