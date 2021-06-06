using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;

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
