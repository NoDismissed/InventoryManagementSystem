using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Sale
    {
        [Key]
        public int Sale_ID { get; set; }
        [Required]
        public int Sale_Amount { get; set; }
        public DateTime Sale_Date { get; set; }
        public Item item { get; set; }
    }
}
