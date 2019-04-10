using System;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    public class Product_Details
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public float Product_Price { get; set; }
        public int Category_ID { get; set; }
        public int Sub_Category_ID { get; set; }
        public string Product_Image { get; set; }

    }
}
