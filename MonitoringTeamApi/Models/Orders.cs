using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringTeamApi.Models
{
    public partial class Orders
    {
        [Key]
        [Column("orderID")]
        public int OrderId { get; set; }
        [Column("totalCost")]
        public string TotalCost { get; set; }
        [Column("purchaseDate", TypeName = "decimal(16, 2)")]
        public decimal? PurchaseDate { get; set; }
        [Column("bicycleID")]
        public int? BicycleId { get; set; }
        [Column("customerID")]
        public int? CustomerId { get; set; }
    }
}
