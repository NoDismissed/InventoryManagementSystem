using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Item
    {
        [Key]
        public int Item_ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Item_Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Item_Description { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Item_Amount { get; set; }
        public DateTime Item_InputDate { get; set; }
    }
}
