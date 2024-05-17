using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class RemoveAddItemAmount
    {
        [Key]
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public string Item_Description { get; set; }
        public int Item_Amount { get; set; }
        public DateTime Item_InputDate { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [RegularExpression(@"^0*[1-9]\d*$", ErrorMessage = "Amount has to be greater than 0")]
        public int RemoveAddAmount { get; set; }
        public bool isAdd { get; set; }
    }

    public class ItemDetails
    {
        [Key]
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public string Item_Description { get; set; }
        public int Item_Amount { get; set; }
        public DateTime Item_InputDate { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
