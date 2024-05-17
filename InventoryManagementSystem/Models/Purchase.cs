using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Purchase
    {
        [Key]
        public int Purchase_ID { get; set; }
        [Required]
        public int Purchase_Amount { get; set; }
        public DateTime Purchase_Date { get; set; }
        public Item item { get; set; }
    }
}
