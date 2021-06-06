using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Promotions
{
    public class PromotionB : Promotion
    {
        public PromotionB(Guid promoId, string productId,int productQuantity,decimal promoPrice,PromoUnit unitOfPromo)
            :base(promoId,productId,productQuantity,promoPrice,unitOfPromo)
        {
            AddStandardPromotion("B", 10);
        }
    }
}
