namespace InventoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InventoryItem
    {
        public InventoryItem()
        {
            Trackings = new HashSet<Tracking>();
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public decimal? Price { get; set; }

        [StringLength(30)]
        public string ItAssetNum { get; set; }

        [StringLength(30)]
        public string CompAssetNum { get; set; }

        [StringLength(50)]
        public string Serial1 { get; set; }

        [StringLength(50)]
        public string Serial2 { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public int ItemId { get; set; }

        public int LocationId { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Tracking> Trackings { get; set; }

        public virtual Item Item { get; set; }

        public virtual Location Location { get; set; }
    }
}
