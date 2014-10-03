namespace InventoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tracking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string JobNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string User { get; set; }

        public int StatusId { get; set; }

        [Required]
        [StringLength(25)]
        public string AddedBy { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public int InventoryItemId { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }

        public virtual Status Status { get; set; }
    }
}
