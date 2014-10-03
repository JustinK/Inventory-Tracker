
namespace InventoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status
    {
        public Status()
        {
            Trackings = new HashSet<Tracking>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Tracking> Trackings { get; set; }
    }
}
