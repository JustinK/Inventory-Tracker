namespace InventoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        public Location()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
