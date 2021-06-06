using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Products
{
    public class ProductB:Product
    {
        public ProductB(string productId, decimal price)
            :base(productId,price)
        {
            AddPromotion(new PromotionB(Guid.NewGuid(), productId, 2, 45m, PromoUnit.FlatPrice));
        }
    }
}
