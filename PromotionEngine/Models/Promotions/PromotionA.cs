using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Promotions
{
    public class PromotionA : Promotion
    {
        public PromotionA(Guid promoId, string productId,int productQuantity,decimal promoPrice,string unitOfPromo)
            :base(promoId,productId,productQuantity,promoPrice,unitOfPromo)
        {
            AddStandardPromotion("A", 10);
        }
    }
}
