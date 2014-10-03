namespace InventoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public Item()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
