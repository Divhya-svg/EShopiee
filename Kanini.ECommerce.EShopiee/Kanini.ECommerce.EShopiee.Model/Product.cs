using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string CartDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public decimal MRP { get; set; }
        public decimal DealPrice { get; set; }
        public decimal SavePrice { get; set; }
        public int NoOfStock { get; set; }
        public bool ProductIsActive { get; set; }

    }
}
