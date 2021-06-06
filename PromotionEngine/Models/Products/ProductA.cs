using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Products
{
    public class ProductA:Product
    {
        public ProductA(string productId, decimal price)
            :base(productId,price)
        {
            AddPromotion(new PromotionA(Guid.NewGuid(), productId, 3, 130m, PromoUnit.FlatPrice));
        }
    }
}
