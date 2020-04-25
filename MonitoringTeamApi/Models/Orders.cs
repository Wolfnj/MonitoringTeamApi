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
        [Column("totalCost", TypeName = "decimal(16, 2)")]
        public decimal? TotalCost { get; set; }
        [Column("purchaseDate")]
        public string PurchaseDate { get; set; }
        [Column("bicycleId")]
        public int? BicycleId { get; set; }
        [Column("customerID")]
        public int? CustomerId { get; set; }
    }
}
