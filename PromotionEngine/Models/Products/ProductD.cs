using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Products
{
    public class ProductD:Product
    {
        public ProductD(string productId, decimal price)
            :base(productId,price)
        {
            //AddPromotion(new Promotion)
        }
    }
}
