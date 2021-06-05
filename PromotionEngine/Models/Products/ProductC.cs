using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Products
{
    public class ProductC:Product
    {
        public ProductC(string productId, decimal price)
            :base(productId,price)
        {
            //AddPromotion(new Promotion)
        }
    }
}
