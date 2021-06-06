using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public List<Product> Products { get; set; }
        public decimal CartValue { get; set; }

        public Order(List<Product> _prods)
        {
            this.OrderID = Guid.NewGuid();
            this.Products = _prods;
        }
    }
}
