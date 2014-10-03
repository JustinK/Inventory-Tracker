using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
